using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;

namespace BusinessModels
{
        public class JsonDataTypeConverter : StringConverter
    {
        //: ITypeConverter where T : class
        //public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        //{
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(text);
        //}

        //public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        //}
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            // Split the CSV string into a list of strings
            var stringList = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return new PathInfo
            {
                Path = stringList[0],
                PathRaw = stringList[1],
                Event_ts = stringList[2],
                Product = stringList[3],
            };
        }
    }
    }
