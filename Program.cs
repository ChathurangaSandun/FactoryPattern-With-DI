using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Options;
using System;

namespace ConsoleApp4
{
  class Program
  {
    static int Main(string[] args)
    {
      var services = ConfigureServices();

      var serviceProvider = services.BuildServiceProvider();

      (var subProcesses, var parameters) = ResolveConsoleCommands(args);

      return serviceProvider.GetService<App>().Run(subProcesses, parameters);



    }

    private static (string, string[]) ResolveConsoleCommands(string[] args)
    {
      var subProcess = string.Empty;
      var parameters = new string[] { };
      var options = new OptionSet {
        {
          "s|SubProcesses=", "", n => {
            if (!string.IsNullOrWhiteSpace(n))
            {
              subProcess = n;
            }
          }
        },
        {
          "p|Parameters=", "",n => {
            if (!string.IsNullOrWhiteSpace(n))
            {
              parameters = n.Split(',');
            }
          }
        },
      };
      options.Parse(args);
      return (subProcess, parameters);
    }


    private static IServiceCollection ConfigureServices()
    {
      var services = new ServiceCollection();

      var configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        //.AddJsonFile(Debugger.IsAttached ? DEV_SETTINGS_JSON : PROD_SETTINGS_JSON, true, true)
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables()
        .Build();

      services.Configure<ApplicationSettings>(configuration.GetSection("Application"));

      services.AddScoped(typeof(IFactory<>), typeof(Factory<>));
      services.AddScoped<IVehicleFactory, VehicleFactory>();
      services.AddScoped<IGenerationService, GenerationService>();
      //services.AddFactory<IVehicleService, CarService>();
      //services.AddFactory<IVehicleService, BikeService>();

      //public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)
      services.AddTransient<CarService>()
             .AddSingleton<Func<CarService>>(x => x.GetService<CarService>);
      services.AddTransient<BikeService>()
                .AddSingleton<Func<BikeService>>(x => x.GetService<BikeService>);



      services.AddScoped<App>();
      return services;
    }
  }
}


