namespace TraiderMagazine.Web
{
    public static class MetaData
    {
        public static string ApiUrl { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
