using BusinessModels;
using CsvHelper;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class QuoteEventService : IQuoteEventService
    {

        public async Task<IEnumerable<Quote_Event>> GetQuoteEventsRecordsAsync()
        {
            var path = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + CsvPaths.BasePath + CsvPaths.QuoteSubPath;
            await using (var fsRead = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fsRead))
                using (var csvReader = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    try
                    {
                        csvReader.Context.Configuration.HeaderValidated = null;
                        csvReader.Context.RegisterClassMap<Quote_EventRecordMap>();
                        var x = csvReader.GetRecords<Quote_Event>().ToList();

                        return x;
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }

                }
            }
        }
    }
}
