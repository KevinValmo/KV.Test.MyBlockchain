using KV.Test.Blockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace KV.Test.Blockchain.Services.Apis.Extensions;

public static class ApiExtensions
{
    public static void MapApis(this WebApplication app) 
    {
        IEnumerable<IApi>? apis = app.Services.GetServices<IApi>();
        List<string> apisRoutes = new List<string>();

        foreach (IApi api in apis)
        {
            if (api is null) throw new InvalidProgramException("Apis not found");
            apisRoutes.AddRange(api.Map(app));
        }

        app.Map("api/", () => Results.Ok(apisRoutes));
    }

    public static string MapApi(this WebApplication app, string pattern, Delegate handler)
    {
        app.Map(pattern, handler);
        return pattern;
    }

    public static void AddApi<TApi, TImplementation>(this IServiceCollection services)
        where TApi : class, IApi
        where TImplementation : class, TApi
    {
        services.AddTransient<TApi, TImplementation>();
    }

    public static void AddApi<TImplementation>(this IServiceCollection services)
        where TImplementation : class, IApi
    {
        services.AddTransient<IApi, TImplementation>();
    }
}
