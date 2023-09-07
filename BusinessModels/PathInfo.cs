using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace BusinessModels
{
    public class PathInfo
    {
        [Name("path")]
        public string Path { get; set; }
        [Name("path_raw")]
        public string PathRaw { get; set; }
        [Name("product")]
        public string Product { get; set; }
        [Name("event_ts")]
        public DateTime event_ts { get; set; }
      
    }
}
