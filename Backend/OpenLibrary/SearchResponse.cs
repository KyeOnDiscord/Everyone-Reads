namespace EveryoneReads.Backend.OpenLibrary
{
    public class SearchResponse
    {

        public class Rootobject
        {
            public int numFound { get; set; }
            public int start { get; set; }
            public bool numFoundExact { get; set; }
            public Doc[] docs { get; set; }
            public int num_found { get; set; }
            public string q { get; set; }
            public object offset { get; set; }
        }

        public class Doc
        {
            public string key { get; set; }
            public string type { get; set; }
            public string[] seed { get; set; }
            public string title { get; set; }
            public string title_suggest { get; set; }
            public int edition_count { get; set; }
            public string[] edition_key { get; set; }
            public string[] publish_date { get; set; }
            public int[] publish_year { get; set; }
            public int first_publish_year { get; set; }
            public int number_of_pages_median { get; set; }
            public string[] lccn { get; set; }
            public string[] publish_place { get; set; }
            public string[] oclc { get; set; }
            public string[] contributor { get; set; }
            public string[] lcc { get; set; }
            public string[] ddc { get; set; }
            public string[] isbn { get; set; }
            public int last_modified_i { get; set; }
            public string[] ia { get; set; }
            public int ebook_count_i { get; set; }
            public bool has_fulltext { get; set; }
            public bool public_scan_b { get; set; }
            public string ia_collection_s { get; set; }
            public string lending_edition_s { get; set; }
            public string lending_identifier_s { get; set; }
            public string printdisabled_s { get; set; }
            public string cover_edition_key { get; set; }
            public int cover_i { get; set; }
            public string[] first_sentence { get; set; }
            public string[] publisher { get; set; }
            public string[] language { get; set; }
            public string[] author_key { get; set; }
            public string[] author_name { get; set; }
            public string[] author_alternative_name { get; set; }
            public string[] person { get; set; }
            public string[] place { get; set; }
            public string[] subject { get; set; }
            public string[] id_alibris_id { get; set; }
            public string[] id_amazon { get; set; }
            public string[] id_bodleian__oxford_university { get; set; }
            public string[] id_depósito_legal { get; set; }
            public string[] id_goodreads { get; set; }
            public string[] id_google { get; set; }
            public string[] id_hathi_trust { get; set; }
            public string[] id_librarything { get; set; }
            public string[] id_paperback_swap { get; set; }
            public string[] id_wikidata { get; set; }
            public string[] id_yakaboo { get; set; }
            public string[] ia_loaded_id { get; set; }
            public string[] ia_box_id { get; set; }
            public string[] publisher_facet { get; set; }
            public string[] person_key { get; set; }
            public string[] place_key { get; set; }
            public string[] person_facet { get; set; }
            public string[] subject_facet { get; set; }
            public long _version_ { get; set; }
            public string[] place_facet { get; set; }
            public string lcc_sort { get; set; }
            public string[] author_facet { get; set; }
            public string[] subject_key { get; set; }
            public string ddc_sort { get; set; }
            public string[] id_amazon_ca_asin { get; set; }
            public string[] id_amazon_co_uk_asin { get; set; }
            public string[] id_amazon_de_asin { get; set; }
            public string[] id_amazon_it_asin { get; set; }
            public string[] id_british_library { get; set; }
            public string[] id_canadian_national_library_archive { get; set; }
            public string[] id_abebooks_de { get; set; }
            public string[] id_british_national_bibliography { get; set; }
            public string[] id_overdrive { get; set; }
            public string[] time { get; set; }
            public string[] time_facet { get; set; }
            public string[] time_key { get; set; }
            public string subtitle { get; set; }
        }

    }
}
