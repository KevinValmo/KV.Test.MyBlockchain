using KV.Test.MyBlockchain.Core.Implementations;
using KV.Test.MyBlockchain.Core.Interfaces;
using KV.Test.MyBlockchain.Services.Apis;
using KV.Test.MyBlockchain.Services.Apis.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KV.Test.MyBlockchain.Services.Boot;

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
        services.AddSingleton<IBlockchain, Blockchain>();
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