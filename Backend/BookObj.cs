using ISOLib.Model;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.CompilerServices;

namespace EveryoneReads.Backend
{
    public class BookObj
    {
        /// <summary>
        /// The book's ISBN13. If an ISBN 10 is set, it will be converted to an ISBN 13
        /// </summary>
        public string ISBN13 { get; set; }

        /// <summary>
        /// The book's Author
        /// </summary>
        public string[] Authors { get; set; } = new string[] { };

        /// <summary>
        /// The book's cover's url
        /// </summary>
        public string CoverURL { get; set; } = string.Empty;

        /// <summary>
        /// The book's publish date
        /// </summary>
        public string PublishDate { get; set; }

        /// <summary>
        /// The book's language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The book's publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The book's page count
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// The book's title
        /// </summary>
        public string Title { get; set; }
        public string GoogleBooksID { get; set; }
        public string[] Categories { get; set; } = new string[] { };

        public BookObj() { }


        public static BookObj DummyBook()
        {
            BookObj bookObj = new();
            bookObj.Title = "Unknown Book";
            bookObj.PageCount = 0;
            return bookObj;
        }

        /// <summary>
        /// Converts google's book item to this project's BookObj class.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private static BookObj CreateBook(GoogleBooks.BookSearch.Item book)
        {
            BookObj newBook = new BookObj();
            if (book.volumeInfo.industryIdentifiers != null)
                newBook.ISBN13 = ConvertISBN10ToISBN13(book.volumeInfo.industryIdentifiers[0].identifier);//Doesn't matter which ISBN we select, either ISBN 10 or ISBN 13 will work because it will automatically be converted.

            if (book.volumeInfo.authors != null)
                newBook.Authors = book.volumeInfo.authors;

            if (book.volumeInfo.imageLinks != null)
            {
                if (book.volumeInfo.imageLinks.smallThumbnail != null)
                    newBook.CoverURL = book.volumeInfo.imageLinks.smallThumbnail;

                if (book.volumeInfo.imageLinks.thumbnail != null)
                    newBook.CoverURL = book.volumeInfo.imageLinks.thumbnail;
            }
            else
            {

#if DEBUG
                newBook.CoverURL = "/NoCover.png";
#else
                newBook.CoverURL = "Everyone-Reads/NoCover.png";
#endif
            }

            if (book.volumeInfo.publishedDate != null)
                newBook.PublishDate = book.volumeInfo.publishedDate;
            if (book.volumeInfo.publisher != null)
                newBook.Publisher = book.volumeInfo.publisher;

            if (book.volumeInfo.language != null)
                newBook.Language = book.volumeInfo.language;

            if (book.volumeInfo.pageCount > 0)
                newBook.PageCount = book.volumeInfo.pageCount;

            if (book.volumeInfo.title != null)
                newBook.Title = book.volumeInfo.title;

            if (book.id != null)
                newBook.GoogleBooksID = book.id;

            if (book.volumeInfo.categories != null)
                newBook.Categories = book.volumeInfo.categories;

            return newBook;
        }

        /// <summary>
        /// Gets books from title, author, ISBN
        /// </summary>
        /// <param name="query">The search term</param>
        /// <param name="count">How many books to return, max is 40</param>
        /// <returns></returns>
        public static async Task<ICollection<BookObj>> GetBook(string query, int count = 40, Language lang = null)
        {
            var googleBooksList = await GoogleBooks.GoogleBooks.SearchBook(query, count, lang);
            ICollection<BookObj> books = new List<BookObj>();
            foreach (var book in googleBooksList)
                books.Add(CreateBook(book));

            return books;
        }


        /// <summary>
        /// Gets books from title, author, ISBN
        /// </summary>
        /// <param name="query">The search term</param>
        /// <param name="count">How many books to return, max is 40</param>
        /// <returns></returns>
        public static async Task<BookObj?> GetBookByID(string googleBooksID)
        {
            var bookData = await GoogleBooks.GoogleBooks.GetBookByGoogleBooksID(googleBooksID);
            if (!string.IsNullOrEmpty(bookData.volumeInfo.title))
            {
                //Successfully obtained book
                return CreateBook(bookData);
            }
            else
            {
                //Invalid book so we just return a 'dummy' book.
                return BookObj.DummyBook();
            }
        }

        public static async Task<BookObj?> GetBookByISBN(string ISBN)
        {
            var bookData = await GoogleBooks.GoogleBooks.GetBookByISBN(ISBN);
            if (!string.IsNullOrEmpty(bookData.volumeInfo.title))
            {
                //Successfully obtained book
                return CreateBook(bookData);
            }
            else
            {
                //Invalid book so we just return a 'dummy' book.
                return BookObj.DummyBook();
            }
        }


        //https://isbn-information.com/convert-isbn-10-to-isbn-13.html
        public static string ConvertISBN10ToISBN13(string ISBN10)
        {
            if (ISBN10.Length == 10)
            {
                string ISBN13 = ISBN10;
                ISBN13 = ISBN13.Remove(ISBN13.Length - 1); //Remove last character
                ISBN13 = "978" + ISBN13; //Add 978 to the front of the ISBN

                int Total = 0;
                for (int i = 1; i <= ISBN13.Length; i++)
                {
                    //If the index is an odd number multiply by 1, if its even number multiply by 3
                    if (i % 2 == 0)
                        Total += int.Parse(ISBN13[i - 1].ToString()) * 3;
                    else
                        Total += int.Parse(ISBN13[i - 1].ToString());
                }

                Total %= 10;

                if (Total == 0)
                    return ISBN13 + "0";
                else
                    return ISBN13 + (10 - Total).ToString();
            }
            else
                return ISBN10;
        }
    }
}
