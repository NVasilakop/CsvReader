using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilizer
{
    public class DBConnectionDetails
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string DBName { get; set; }
        public  UserCredentials UserCredentials { get; set; }
        public int CommandTimeout { get; set; }
        public int Timeout { get; set; }
        public int MaxPoolSize { get; set; }
        public int KeepAlive { get; set; }
        public bool Pooling { get; set; }
    }
    public  class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
