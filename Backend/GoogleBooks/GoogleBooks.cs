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
        /// <returns></returns>
        public static async Task<BookSearch.Rootobject?> SearchBook(string query)
        {
            var resp = await Http.GetAsync($"https://www.googleapis.com/books/v1/volumes?maxResults=40&q={query}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookSearch.Rootobject>(content);

            }
            throw new Exception($"Query: {query} , could not be found on Google Books");
            return null;
        }


    }
}
