using KV.Test.Blockchain.Core.Implementations;
using KV.Test.Blockchain.Core.Interfaces;

namespace KV.Test.Blockchain.Services.Boot;

public class Startup
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        WebApplication? app = builder.Build();
        
        ConfigureHttpPipeline(app);

        app.Run();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //services.AddTransient<IBlockFactory<IBlock>, BlockFactory<Block>>();
        services.AddSingleton<IBlockchain, Core.Implementations.Blockchain>();
    }

    public static void ConfigureHttpPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}