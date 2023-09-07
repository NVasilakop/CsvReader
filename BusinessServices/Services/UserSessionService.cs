using BusinessModels;
using CsvHelper;
using Interfaces;
using System.Globalization;
using System.IO;

namespace Services
{
    public class UserSessionService : IUserSessionService
    {
        //private CsvReader _csvReader;
        public UserSessionService()
        {
            var x = CsvPaths.SessionSubPath;
            
        }

        public async Task<IEnumerable<Session>> GetSessions()
        {
            var path = Path.GetDirectoryName(Directory.GetCurrentDirectory())+ CsvPaths.BasePath + CsvPaths.SessionSubPath;
            await using (var fsRead = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fsRead))
                using (var csvReader = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    try
                    {
                        //csvReader.Context.Configuration.Delimiter = ",";
                        csvReader.Context.Configuration.HeaderValidated = null;
                        //csvReader.Configuration.RegisterClassMap<SessionRecordMap>();
                        //csvReader.Context.RegisterClassMap<SessionRecordMap>();
                        //csvReader.Read();
                        //csvReader.ReadHeader();
                        var x = csvReader.GetRecords<Session>();

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