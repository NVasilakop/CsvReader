using BusinessModels;
using CsvHelper;
using Interfaces;
using System.Globalization;
using System.IO;

namespace Services
{
    public class UserSessionService : IUserSessionService
    {
        public UserSessionService()
        {
           
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            var path = Path.GetDirectoryName(Directory.GetCurrentDirectory())+ CsvPaths.BasePath + CsvPaths.SessionSubPath;
            await using (var fsRead = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fsRead))
                using (var csvReader = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    try
                    {
                        csvReader.Context.Configuration.HeaderValidated = null;
                        csvReader.Context.RegisterClassMap<SessionRecordMap>();
                        var x = csvReader.GetRecords<Session>().ToList();

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