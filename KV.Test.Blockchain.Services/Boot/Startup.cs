using KV.Test.Blockchain.Core.Implementations;
using KV.Test.Blockchain.Core.Interfaces;
using KV.Test.Blockchain.Services.Apis;
using KV.Test.Blockchain.Services.Apis.Extensions;
using KV.Test.Blockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KV.Test.Blockchain.Services.Boot;

public class Startup
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        WebApplication? app = builder.Build();
        
        ConfigureApplication(app);

        app.Run();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddApi<BlockchainApis>();
        
        services.AddTransient<IBlockFactory<IBlock>, BlockFactory>();
        services.AddSingleton<IBlockchain, Core.Implementations.Blockchain>();
    }

    public static void ConfigureApplication(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {

        }

        app.MapApis();

        app.UseHttpsRedirection();
    }
}