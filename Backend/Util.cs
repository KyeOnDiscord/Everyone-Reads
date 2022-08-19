using ISOLib.ISO;
using ISOLib.Model;

namespace EveryoneReads.Backend
{
    public static class Util
    {
        public static readonly HttpClient Http = new HttpClient();

        public static List<BookObj> Wishlist = new();
        public static List<BookObj> MyBooks = new();


        public static IEnumerable<Language> GetLanguageList()
        {
            ISO<Language> iso639 = new ISO639();
            return iso639.GetArray();
        }
    }
}
