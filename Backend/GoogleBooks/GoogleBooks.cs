using Newtonsoft.Json;

namespace EveryoneReads.Backend.GoogleBooks
{

    public static class GoogleBooks
    {
        private const string BaseURL = "https://www.googleapis.com/books/v1";
        private static HttpClient Http = new HttpClient();

        /// <summary>
        /// Fetches a list of books from title
        /// </summary>
        /// <param name="query">Title of the book</param>
        /// <param name="count">Number of books to return, max 40</param>
        /// <returns></returns>
        public static async Task<BookSearch.Rootobject?> SearchBook(string query, int count = 40)
        {
            var resp = await Http.GetAsync($"{BaseURL}/volumes?maxResults={count}&q={query}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Rootobject>(content);

            }

            throw new Exception($"Query: {query} , could not be found on Google Books");
        }


        /// <summary>
        /// Gets a single book from it's Google Books ID
        /// </summary>
        /// <param name="googleBooksID">The google book's ID of the book to return</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<BookSearch.Item?> GetBook(string googleBooksID)
        {
            var resp = await Http.GetAsync($"{BaseURL}/volumes/{googleBooksID}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Item>(content);

            }
            throw new Exception($"Google Book ID: {googleBooksID} , could not be found on Google Books");
        }


    }
}
