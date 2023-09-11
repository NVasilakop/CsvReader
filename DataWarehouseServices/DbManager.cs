using BusinessModels;
using DataWarehouseInterfaces;
using System.Transactions;
using Utilizer;
using static System.Formats.Asn1.AsnWriter;

namespace DataWarehouseServices
{
    public class DbManager
    {
        private readonly DataWarehouseInterfaces.IUserSessionService _userSessionService;
        private readonly DataWarehouseInterfaces.IPolicyService _policyService;
        private readonly IQuoteService _quoteService;
        private readonly IMasterService _masterService;
        private IDbConnectionFactory _dbConnectionFactory;
        private RecordTransformator _recordTransformator;

        public DbManager(DataWarehouseInterfaces.IUserSessionService userSessionService,
           RecordTransformator recordTransformator,
          DataWarehouseInterfaces.IPolicyService policyService, IQuoteService quoteService, IMasterService masterService, IDbConnectionFactory dbConnectionFactory)
        {
            _userSessionService = userSessionService;
            _policyService = policyService;
            _quoteService = quoteService;
            _masterService = masterService;
            _dbConnectionFactory = dbConnectionFactory;
            _recordTransformator = recordTransformator;
        }

        public async Task InsertDBRows()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var conn = _dbConnectionFactory.CreateConnection())
                    {
                        conn.Open();
                        await _userSessionService.WriteUserSessionsToDB(_recordTransformator.GetUserSessions(), conn);
                        await _quoteService.WriteQuotesSnapshotsToDB(_recordTransformator.GetQuotes(), conn);
                        await _userSessionService.WriteUserSessionQuotesToDB(_recordTransformator.GetUserSessionQuotes(), conn);
                        await _policyService.WritePoliciesToDB(_recordTransformator.GetPolicies(), conn);
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public async Task InsertQuotesAndStoredProcedureItems()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var conn = _dbConnectionFactory.CreateConnection())
                    {
                        conn.Open();
                        await _quoteService.WriteQuotesToDB(_recordTransformator.GetQuotes(), conn);
                        await _masterService.WriteMasterToDB(conn);
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
                              
  
    }
}
