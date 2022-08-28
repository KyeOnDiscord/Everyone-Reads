using Newtonsoft.Json;
using ISOLib.Model;

namespace EveryoneReads.Backend.GoogleBooks
{

    public static class GoogleBooks
    {
        private const string BaseURL = "https://www.googleapis.com/books/v1";

        //Google Books API Query Parameters https://developers.google.com/books/docs/v1/using#query-params

        /// <summary>
        /// Fetches a list of books from title
        /// </summary>
        /// <param name="query">Title of the book</param>
        /// <param name="count">Number of books to return, max 40</param>
        /// <returns></returns>
        public static async Task<ICollection<BookSearch.Item>> SearchBook(string query, int count = 40, Language language = null)
        {
            string LanguageQueryParameter = string.Empty;
            if (language != null)
                LanguageQueryParameter = $"&langRestrict={language.Alpha2}";

            var resp = await Util.Http.GetAsync($"{BaseURL}/volumes?maxResults={count}&q={query}{LanguageQueryParameter}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();

                var deserializedResp = JsonConvert.DeserializeObject<BookSearch.Rootobject>(content);
                if (deserializedResp.items != null)
                {
                    if (language != null)
                        return deserializedResp.items.Where(x => x.volumeInfo.language.Equals(language.Alpha2)).ToList();
                    else
                        return deserializedResp.items;
                }
            }
            return new BookSearch.Item[] { };
        }



        /// <summary>
        /// Fetches a list of books by Author
        /// </summary>
        /// <param name="author">The author's works to return</param>
        /// <param name="count">Number of books to return, max 40</param>
        /// <returns></returns>
        public static async Task<ICollection<BookSearch.Item>> GetBookByAuthor(string author, int count = 40, Language language = null)
        {
            string LanguageQueryParameter = string.Empty;
            if (language != null)
                LanguageQueryParameter = $"&langRestrict={language.Alpha2}";

            var resp = await Util.Http.GetAsync($"{BaseURL}/volumes?maxResults={count}&q=+inauthor:{author}{LanguageQueryParameter}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();

                var deserializedResp = JsonConvert.DeserializeObject<BookSearch.Rootobject>(content);
                if (deserializedResp.items != null)
                {
                    if (language != null)
                        return deserializedResp.items.Where(x => x.volumeInfo.language.Equals(language.Alpha2)).ToList();
                    else
                        return deserializedResp.items;
                }
            }
            return new BookSearch.Item[] { };
        }


        /// <summary>
        /// Gets a single book from its Google Books ID
        /// </summary>
        /// <param name="googleBooksID">The google book's ID of the book to return</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<BookSearch.Item> GetBookByGoogleBooksID(string googleBooksID)
        {
            var resp = await Util.Http.GetAsync($"{BaseURL}/volumes/{googleBooksID}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Item>(content);
            }

            return new BookSearch.Item { };
        }

        /// <summary>
        /// Gets a single book by its ISBN
        /// </summary>
        /// <param name="ISBN">The ISBN of the book to return</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<BookSearch.Item> GetBookByISBN(string ISBN)
        {
            var resp = await Util.Http.GetAsync($"{BaseURL}/volumes?q=+isbn:{ISBN}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Rootobject>(content).items[0];
            }

            return new BookSearch.Item { };
        }


    }
}
