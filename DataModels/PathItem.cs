namespace DataModels
{
    public sealed class PathItem
    {
        public string Path { get; set; }
        public string PathRaw { get; set; }
        public DateTime? Event_Ts { get; set; }
        public string Product { get; set; }
        public string QuoteReference { get; set; }
    }
}
