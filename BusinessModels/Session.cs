using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;

namespace BusinessModels
{
    public class Session
    {

        [Ignore]
        public string FirstColumn { get; set; }
        [Index(1)]
        [Name("_id")]
        public string Id { get; set; }

        [Name("uuid")]
        public string UserId { get; set; }

        [Name("C_ts")]
        public DateTime Record_Creation_Ts { get; set; }

        [Name("P_ts")]
        public DateTime Last_Record_Update_Ts { get; set; }

        //[Name("paths")]
        //[JsonConverter(typeof(JsonDataConverter<PathInfo[]>))]
        //public PathInfo[] Paths { get; set; }

        [Name("entry_ts")]
        public DateTime Entry_Ts { get; set; }

        [Name("exit_ts")]
        public DateTime Exit_Ts { get; set; }

    }
}