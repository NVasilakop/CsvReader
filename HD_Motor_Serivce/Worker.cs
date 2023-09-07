using Interfaces;
using Microsoft.Extensions.Options;

namespace HD_Motor_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserSessionService _userSessionService;
        //IOptions<CsvPaths> _customSettings;

        public Worker(ILogger<Worker> logger,IUserSessionService userSessionService)
        {
            _logger = logger;
            _userSessionService = userSessionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                ReaderItems readerItems = new ReaderItems(_userSessionService,null);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}