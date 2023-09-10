using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public sealed class Master
    {
        public string SessionId { get; set; }
        public string Paths { get; set; }
        public string PolicyId { get; set; }
    }
}
