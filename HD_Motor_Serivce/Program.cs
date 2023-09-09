using AutoMapper;
using BusinessModels.Profiles;
using DataWarehouseInterfaces;
using DataWarehouseServices;
using HD_Motor_Service;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Configuration;
using System.Runtime.CompilerServices;
using Utilizer;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                var myCustomSettings = new DBConnectionDetails();
                config.GetSection("DBConnectionDetails").Bind(myCustomSettings);
                services.AddSingleton(myCustomSettings);

                var x = config.GetValue<string>("CsvPaths:SessionSubPath");
                CsvPaths.BasePath = config.GetValue<string>("CsvPaths:BasePath");
                CsvPaths.PolicySubPath = config.GetValue<string>("CsvPaths:PolicySubPath");
                CsvPaths.QuoteSubPath = config.GetValue<string>("CsvPaths:QuoteSubPath");
                CsvPaths.SessionSubPath = config.GetValue<string>("CsvPaths:SessionSubPath");
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                RegisterDBInfra(services);
                RegisterBusinessServices(services);
                RegisterDataServices(services);
                services.AddHostedService<Worker>();
            })
            .Build();

        var scope = host.Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<IDbConnectionFactory>().CreateDbTables();
        host.Run();
    }

    private static void RegisterBusinessServices(IServiceCollection services)
    {
        services.AddSingleton<Interfaces.IUserSessionService, Services.UserSessionService>();
        services.AddSingleton<IQuoteEventService,QuoteEventService>();
        services.AddSingleton<Interfaces.IPolicyService, Services.PolicyService>();
        services.AddSingleton<IReaderService,ReaderService>();
    }

    private static void RegisterDataServices(IServiceCollection services)
    {
        services.AddSingleton<DataWarehouseInterfaces.IUserSessionService, DataWarehouseServices.UserSessionService>();
        services.AddSingleton<IQuoteService, QuoteService>();
        services.AddSingleton<DataWarehouseInterfaces.IPolicyService, DataWarehouseServices.PolicyService>();
        services.AddSingleton<DataWarehouseInterfaces.IMasterService, DataWarehouseServices.MasterService>();
    }

    private static void RegisterDBInfra(IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
    }

}