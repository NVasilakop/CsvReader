using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQuoteEventService
    {
        Task<IEnumerable<Quote_Event>> GetQuoteEventsRecordsAsync();
    }
}
