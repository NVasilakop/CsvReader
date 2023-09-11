using AutoMapper;
using DataModels;
using System;

namespace BusinessModels
{
    public class RecordTransformator
    {
        private IMapper _mapper { get; set; }
        private IEnumerable<UserSession> _userSessions;
        private IEnumerable<Quote> _quotes;
        private IEnumerable<DataModels.Policy> _policies;
        private IEnumerable<UserSessionQuote> _userSessionQuotes;
        public RecordTransformator(IMapper mapper, CsvRecordResults records)
        {
            _mapper = mapper;
            _userSessions = _mapper.Map<IEnumerable<UserSession>>(records.Sessions);
            _policies = _mapper.Map<IEnumerable<DataModels.Policy>>(records.Policies);
            _quotes = _mapper.Map<IEnumerable<Quote>>(records.Quote_Events);
            _userSessionQuotes = GetUserSessionQuotes(records.Sessions);
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

        public IEnumerable<UserSessionQuote> GetUserSessionQuotes()
        {
            return _userSessionQuotes;
        }

        private IEnumerable<UserSessionQuote> GetUserSessionQuotes(IEnumerable<Session> sessions)
        {
            List<UserSessionQuote> list = new List<UserSessionQuote>();
            foreach (var item in sessions)
            {
                foreach (var pathItem in Resolve(item.Paths))
                {
                    var userSessionQuote = _mapper.Map<Session, UserSessionQuote>(item);
                    userSessionQuote.QuoteReference = pathItem.QuoteReference;
                    userSessionQuote.Event_Ts = pathItem.Event_Ts;
                    userSessionQuote.Product = pathItem.Product;
                    userSessionQuote.Path = pathItem.Path;
                    userSessionQuote.PathRaw = pathItem.PathRaw;
                    list.Add(userSessionQuote);
                }
            }
            return list.GroupBy(q=>q.QuoteReference).Select(group => group.OrderByDescending(q => q.Event_Ts).First()); 
        }

        public IEnumerable<PathItem> Resolve(string jsonItem)
        {
            var pathsJson = jsonItem;
            List<PathItem> pathItems = new List<PathItem>();

            if (string.IsNullOrEmpty(pathsJson))
            {
                return pathItems;
            }

            string[] jsonChunks = pathsJson.Trim('[', ']').Split(new[] { "}, {" }, StringSplitOptions.None);
            foreach (string chunk in jsonChunks)
            {
                var subChunks = chunk.Replace("'", "").Trim('{', '}');
                var pathValue = GetPartAfterKey(subChunks, "path:") != null ?
                     GetPartAfterKey(subChunks, "path:").Split(new[] { ',' }, StringSplitOptions.None)[0] : null;
                var pathRaw = GetPartAfterKey(subChunks, "path_raw:") != null ?
                     GetPartAfterKey(subChunks, "path_raw:").Split(new[] { ',' }, StringSplitOptions.None)[0] : null;
                var event_ts = GetPartAfterKey(subChunks, "event_ts:") != null ?
                     GetPartAfterKey(subChunks, "event_ts:").Split(new[] { ')' }, StringSplitOptions.None)[0] + ")" : null;
                var product = GetPartAfterKey(subChunks, "product:") != null ?
                     GetPartAfterKey(subChunks, "product:").Split(new[] { ',' }, StringSplitOptions.None)[0] : null;
                var qref = GetPartAfterKey(subChunks, "q_ref:") != null
                     ? GetPartAfterKey(subChunks, "q_ref:").Split(new[] { ',' }, StringSplitOptions.None)[0] : null;
                pathItems.Add(new PathItem
                {
                    //Event_Ts = DateTime.TryParse(event_ts, out var date) ? date : DateTime.MinValue,
                    Event_Ts = ParseDatetimeString(event_ts),
                    Path = pathValue,
                    PathRaw = pathRaw,
                    Product = product,
                    QuoteReference = qref
                });
            }
            return pathItems;
        }

        private static string GetPartAfterKey(string input, string key)
        {
            int keyIndex = input.IndexOf(key);
            if (keyIndex >= 0)
            {
                keyIndex += key.Length;
                return input.Substring(keyIndex).Trim();
            }
            return null;
        }

        private DateTime ParseDatetimeString(string input)
        {

            string[] parts = input.Split(',', '(', ')');
            var year = int.TryParse(parts[1], out var yr) ? yr : 0;
            var month = int.TryParse(parts[2], out var mon) ? mon : 0;
            var day = int.TryParse(parts[3], out var d) ? d : 0;
            var hour = int.TryParse(parts[4], out var hr) ? hr : 0;
            var minute = int.TryParse(parts[5], out var min) ? min : 0;
            var second = int.TryParse(parts[6], out var sec) ? sec : 0;

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
