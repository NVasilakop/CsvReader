using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class UserSessionQuote
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime Record_Creation_Ts { get; set; }
        public DateTime Last_Record_Update_Ts { get; set; }
        public string Path { get; set; }
        public string PathRaw { get; set; }
        public DateTime? Event_Ts { get; set; }
        public string Product { get; set; }
        public string QuoteReference { get; set; }
        public DateTime Entry_Ts { get; set; }
        public DateTime Exit_Ts { get; set; }
    }
}
