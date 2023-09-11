using BusinessModels;
using DataWarehouseInterfaces;
using Microsoft.Extensions.Logging;
using Services;
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

        public DbManager(WarehouseServiceWrapper wrapper,
           RecordTransformator recordTransformator,IDbConnectionFactory dbConnectionFactory)
        {
            _userSessionService = wrapper.GetUserSessionService();
            _policyService = wrapper.GetPolicyService();
            _quoteService = wrapper.GetQuoteService();
            _masterService = wrapper.GetMasterService();
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
            _recordTransformator = recordTransformator ?? throw new ArgumentNullException(nameof(recordTransformator));
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
        public async Task InsertStoredProcedureItems()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    using (var conn = _dbConnectionFactory.CreateConnection())
                    {
                        conn.Open();
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
