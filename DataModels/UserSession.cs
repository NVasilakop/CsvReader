namespace DataModels
{
    public class UserSession
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Path { get; set; }
        public string PathRaw { get; set; }
        public string Product { get; set; }
        public DateTime Entry_Ts { get; set; }
        public DateTime Exit_Ts { get; set; }
        public DateTime Record_Creation_Ts { get; set; }
        public DateTime Last_Record_Update_Ts { get; set; }
    }
}