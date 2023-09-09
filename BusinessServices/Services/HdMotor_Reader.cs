using BusinessModels;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HdMotor_Reader
    {
        private readonly IUserSessionService _userSessionService;
        private readonly IPolicyService _policyService;
        private readonly IQuoteEventService _quoteEventService;

        public HdMotor_Reader(IUserSessionService userSessionService, IPolicyService policyService, IQuoteEventService quoteEventService)
        {
            _userSessionService = userSessionService;
            _policyService = policyService;
            _quoteEventService = quoteEventService;
        }

        public async Task<CsvRecordResults> ReadRecords()
        {
            var userSessionTask =  _userSessionService.GetSessionsAsync();
            var quoteEventsTask =  _quoteEventService.GetQuoteEventsRecordsAsync();
            var policyTask =  _policyService.GetPolicyRecordsAsync();
            return new CsvRecordResults
            {
                Policies = await policyTask,
                Quote_Events = await quoteEventsTask,
                Sessions = await userSessionTask
            };
        }
    }
}
