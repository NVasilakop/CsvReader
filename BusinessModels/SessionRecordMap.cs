using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public sealed class SessionRecordMap : ClassMap<Session>
    {
            public SessionRecordMap()
            {
                Map(m => m.Id).Name("_id");
                Map(m => m.UserId).Name("uuid");
                Map(m => m.Record_Creation_Ts).Name("C_ts");
                Map(m => m.Last_Record_Update_Ts).Name("P_ts");
                //Map(m => m.Paths).Name("paths");
                Map(m => m.Entry_Ts).Name("entry_ts");
                Map(m => m.Exit_Ts).Name("exit_ts");
            }
     
    }
}
