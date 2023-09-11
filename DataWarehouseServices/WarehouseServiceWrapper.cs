using DataWarehouseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseServices
{
    public sealed class WarehouseServiceWrapper
    {
        private readonly DataWarehouseInterfaces.IPolicyService _dataWarehousePolicyService;
        private readonly DataWarehouseInterfaces.IMasterService _dataWarehouseMasterService;
        private readonly DataWarehouseInterfaces.IQuoteService _dataWarehouseQuoteService;
        private readonly DataWarehouseInterfaces.IUserSessionService _dataWarehouseUserSessionService;

        public WarehouseServiceWrapper(DataWarehouseInterfaces.IUserSessionService userSessionService ,
            DataWarehouseInterfaces.IPolicyService dataWarehousePolicyService,
        DataWarehouseInterfaces.IMasterService dataWarehouseMasterService, DataWarehouseInterfaces.IQuoteService dataWarehouseQuoteService) {

            _dataWarehouseUserSessionService = userSessionService ?? throw new ArgumentNullException(nameof(userSessionService));
            _dataWarehousePolicyService = dataWarehousePolicyService ?? throw new ArgumentNullException(nameof(dataWarehousePolicyService));
            _dataWarehouseQuoteService = dataWarehouseQuoteService ?? throw new ArgumentNullException(nameof(dataWarehouseQuoteService));
            _dataWarehouseMasterService = dataWarehouseMasterService ?? throw new ArgumentNullException(nameof(dataWarehouseMasterService));
        }

        public IPolicyService GetPolicyService()
        {
            return _dataWarehousePolicyService;
        }
        public IQuoteService GetQuoteService()
        {
            return _dataWarehouseQuoteService;
        }
        public IMasterService GetMasterService()
        {
            return _dataWarehouseMasterService;
        }
        public IUserSessionService GetUserSessionService()
        {
            return _dataWarehouseUserSessionService;
        }

    }
}
