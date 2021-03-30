using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using static System.Console;

namespace restsharptest
{
    public class Program
    {

        private static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.Services.GetRequiredService<TodosMenu>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<TodosMenu>();
                    services.Configure<ClientSettings>(hostContext.Configuration.GetSection(nameof(ClientSettings)));
                    services.AddTransient<ITodosService, TodosService>();
                });
        }
    }
}