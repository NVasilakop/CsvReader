namespace DataModels
{
    public sealed class UserSession
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Record_Creation_Ts { get; set; }
        public DateTime Last_Record_Update_Ts { get; set; }
        public string Paths { get; set; }
        public DateTime Entry_Ts { get; set; }
        public DateTime Exit_Ts { get; set; }
    }
}