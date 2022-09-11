namespace EveryoneReads.Backend
{
    public static class BarcodeReader
    {
        public static async Task<string> ReadISBNBarcode(Stream stream)
        {
            HttpContent byteContent = new StreamContent(stream);
            HttpResponseMessage response = await Util.Http.PostAsync("https://localhost:7097/barcode", byteContent);
            if (response.IsSuccessStatusCode )
            {
                string isbn = await response.Content.ReadAsStringAsync();
                return isbn;
            }

            return null;
        }
    }
}