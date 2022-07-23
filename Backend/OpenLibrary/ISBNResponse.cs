namespace EveryoneReads.Backend.OpenLibrary
{
    public class ISBNResponse
    {

        public class Rootobject
        {
            public string[] publishers { get; set; }
            public int number_of_pages { get; set; }
            public int[] covers { get; set; }
            public string key { get; set; }
            public Author[] authors { get; set; }
            public string[] publish_places { get; set; }
            public Language[] languages { get; set; }
            public string pagination { get; set; }
            public string[] source_records { get; set; }
            public string title { get; set; }
            public Identifiers identifiers { get; set; }
            public string edition_name { get; set; }
            public string[] isbn_10 { get; set; }
            public string publish_date { get; set; }
            public string publish_country { get; set; }
            public string by_statement { get; set; }
            public string[] oclc_numbers { get; set; }
            public Work[] works { get; set; }
            public Type type { get; set; }
            public string[] lc_classifications { get; set; }
            public int latest_revision { get; set; }
            public int revision { get; set; }
            public Created created { get; set; }
            public Last_Modified last_modified { get; set; }
        }

        public class Identifiers
        {
            public string[] librarything { get; set; }
            public string[] goodreads { get; set; }
        }

        public class Type
        {
            public string key { get; set; }
        }

        public class Created
        {
            public string type { get; set; }
            public DateTime value { get; set; }
        }

        public class Last_Modified
        {
            public string type { get; set; }
            public DateTime value { get; set; }
        }

        public class Author
        {
            public string key { get; set; }
        }

        public class Language
        {
            public string key { get; set; }
        }

        public class Work
        {
            public string key { get; set; }
        }

    }
}
