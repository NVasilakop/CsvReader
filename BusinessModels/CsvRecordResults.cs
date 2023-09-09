using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class CsvRecordResults
    {
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<Policy> Policies { get; set; }
        public IEnumerable<Quote_Event> Quote_Events { get; set; }

    }
}
