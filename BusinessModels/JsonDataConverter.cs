using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper.TypeConversion;

namespace BusinessModels
{
  
        public class JsonDataConverter<T> : ITypeConverter where T : class
        {
            public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                return JsonConvert.DeserializeObject<T>(text);
            }

            public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            {
                return JsonConvert.SerializeObject(value);
            }
        }

}
