using System.Text.Json;

namespace EveryoneReads.Backend.OpenLibrary
{
    public static class OpenLibrary
    {
        private const string BaseURL = "https://openlibrary.org/";
        private static HttpClient HttpClient = new HttpClient() { BaseAddress = new Uri(BaseURL) };

        /// <summary>
        /// Returns information about a book from its ISBN
        /// </summary>
        /// <param name="ISBN">The book's ISBN</param>
        /// <returns></returns>
        public static async Task<ISBNResponse.Rootobject?> GetBookByISBN(string ISBN)
        {
            var resp = await HttpClient.GetAsync($"/isbn/{ISBN}.json");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ISBNResponse.Rootobject?>(content);

            }

            return null;
        }


        /// <summary>
        /// Returns information about a book from its ISBN
        /// </summary>
        /// <param name="ISBN">The book's ISBN</param>
        /// <returns></returns>
        public static async Task<SearchResponse.Rootobject?> GetBookByTitle(string Title)
        {
            var resp = await HttpClient.GetAsync($"/search.json?title={Title}");
            if (resp.IsSuccessStatusCode)
            {
                string content = await resp.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SearchResponse.Rootobject?>(content);

            }

            return null;
        }


        ///// <summary>
        ///// Returns information about a book from its ISBN
        ///// </summary>
        ///// <param name="ISBN">The book's ISBN</param>
        ///// <returns></returns>
        //public static async Task<SearchResponse.Rootobject?> GetBookCover(string ISBN, )
        //{
        //    var resp = await HttpClient.GetAsync($"/search.json?title={Title}");
        //    if (resp.IsSuccessStatusCode)
        //    {
        //        string content = await resp.Content.ReadAsStringAsync();
        //        return JsonSerializer.Deserialize<SearchResponse.Rootobject?>(content);

        //    }

        //    return null;
        //}




    }
}
