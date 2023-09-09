using AutoMapper;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class RecordTransformator
    {
        private IMapper _mapper { get; set; }
        private IEnumerable<UserSession> _userSessions;
        private IEnumerable<Quote> _quotes;
        private IEnumerable<DataModels.Policy> _policies;
        public RecordTransformator(IMapper mapper,CsvRecordResults records) {
            _mapper = mapper;
            _userSessions = _mapper.Map<IEnumerable<UserSession>>(records.Sessions);
            _policies = _mapper.Map<IEnumerable<DataModels.Policy>>(records.Policies);
            _quotes = _mapper.Map<IEnumerable<Quote>>(records.Quote_Events);
        }

        public IEnumerable<UserSession> GetUserSessions()
        {
            return _userSessions;
        }

        public IEnumerable<DataModels.Policy> GetPolicies()
        {
            return _policies;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _quotes;
        }
    }
}
