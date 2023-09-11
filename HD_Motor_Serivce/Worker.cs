using AutoMapper;
using BusinessModels;
using BusinessModels.Profiles;
using DataWarehouseServices;
using Interfaces;
using Microsoft.Extensions.Options;
using Services;
using Utilizer;

namespace HD_Motor_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserSessionService _userSessionService;
        private readonly IQuoteEventService _quoteEventService;
        private readonly IPolicyService _policyService;
        private readonly IMapper _mapper;
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly WarehouseServiceWrapper _warehouseServiceWrapper;

        public Worker(ILogger<Worker> logger, IUserSessionService userSessionService, DataWarehouseInterfaces.IUserSessionService dataUserSessionService,
            IPolicyService policyService, IQuoteEventService quoteEventService, DataWarehouseInterfaces.IPolicyService dataWarehousePolicyService,
            DataWarehouseInterfaces.IQuoteService dataWarehouseQuoteService, DataWarehouseInterfaces.IMasterService dataWarehouseMasterService,
           IDbConnectionFactory dbConnectionFactory)
        {
            _logger = logger;
            _userSessionService = userSessionService;
            _policyService = policyService;
            _quoteEventService = quoteEventService;
            _warehouseServiceWrapper = new WarehouseServiceWrapper(dataUserSessionService, dataWarehousePolicyService, dataWarehouseMasterService, dataWarehouseQuoteService);
            _dbConnectionFactory = dbConnectionFactory;
            var mapperConfig = new MapperConfiguration(
         cfg =>
         {
             cfg.AddProfile(new SessionProfiler());
             cfg.AddProfile(new QuoteProfiler());
             cfg.AddProfile(new PolicyProfiler());
         });
            _mapper = new Mapper(mapperConfig);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                HdMotor_Reader motor_reader = new HdMotor_Reader(_userSessionService, _policyService, _quoteEventService);
                var records = await motor_reader.ReadRecords();
                var recordTransformator = new RecordTransformator(_mapper, records);
                var dbManager = new DbManager(_warehouseServiceWrapper, recordTransformator, _dbConnectionFactory);
                await dbManager.InsertDBRows();
                await dbManager.InsertStoredProcedureItems();
                await Task.Delay(3600000, stoppingToken);
            }
        }
    }
}