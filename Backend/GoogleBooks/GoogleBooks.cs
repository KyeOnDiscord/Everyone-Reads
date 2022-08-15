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
        public static async Task<BookSearch.Item[]> SearchBook(string query, int count = 40)
        {
            var resp = await Http.GetAsync($"{BaseURL}/volumes?maxResults={count}&q={query}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();

                var deserializedResp = JsonConvert.DeserializeObject<BookSearch.Rootobject>(content);
                if (deserializedResp.items != null)
                    return deserializedResp.items;
            }

            return new BookSearch.Item[] { };
            //throw new Exception($"Query: {query} , could not be found on Google Books");
        }


        /// <summary>
        /// Gets a single book from its Google Books ID
        /// </summary>
        /// <param name="googleBooksID">The google book's ID of the book to return</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<BookSearch.Item> GetBookByGoogleBooksID(string googleBooksID)
        {
            var resp = await Http.GetAsync($"{BaseURL}/volumes/{googleBooksID}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Item>(content);
            }

            return new BookSearch.Item { };
            //throw new Exception($"Google Book ID: {googleBooksID} , could not be found on Google Books");
        }

        /// <summary>
        /// Gets a single book by its ISBN
        /// </summary>
        /// <param name="ISBN">The ISBN of the book to return</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<BookSearch.Item> GetBookByISBN(string ISBN)
        {
            var resp = await Http.GetAsync($"{BaseURL}/volumes?q=+isbn:{ISBN}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Rootobject>(content).items[0];
            }

            return new BookSearch.Item { };
            //throw new Exception($"Google Book ID: {googleBooksID} , could not be found on Google Books");
        }


    }
}
