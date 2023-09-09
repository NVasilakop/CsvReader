using BusinessModels;
using CsvHelper;

namespace Interfaces
{
    public interface IUserSessionService
    {
        Task<IEnumerable<Session>> GetSessionsAsync();
    }
}