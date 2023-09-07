using HD_Motor_Service;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Configuration;
using System.Runtime.CompilerServices;

var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        var x = config.GetValue<string>("CsvPaths:SessionSubPath");

        CsvPaths.BasePath = config.GetValue<string>("CsvPaths:BasePath");
        CsvPaths.PolicySubPath = config.GetValue<string>("CsvPaths:PolicySubPath");
        CsvPaths.QuoteSubPath = config.GetValue<string>("CsvPaths:QuoteSubPath");
        CsvPaths.SessionSubPath = config.GetValue<string>("CsvPaths:SessionSubPath");

        services.AddSingleton<IUserSessionService, UserSessionService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
