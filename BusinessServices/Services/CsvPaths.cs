using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class CsvPaths
    {
        public static string BasePath;
        public static string SessionSubPath;
        public static string QuoteSubPath;
        public static string PolicySubPath;

        public static string GetBasePath()
        {
            return BasePath;
        }
        public static string GetSessionSubPath()
        {
            return SessionSubPath;
        }
        public static string GetQuoteSubPath()
        {
            return QuoteSubPath;
        }
        public static string GetPolicySubPath()
        {
            return PolicySubPath;
        }

    }
}
