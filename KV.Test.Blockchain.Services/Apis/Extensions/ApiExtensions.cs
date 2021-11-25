using KV.Test.MyBlockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace KV.Test.MyBlockchain.Services.Apis.Extensions;

public static class ApiExtensions
{
    public static void MapApis(this WebApplication app)
    {
        IEnumerable<IApi>? apis = app.Services.GetServices<IApi>();

        foreach (IApi api in apis)
        {
            if (api is null)
                throw new InvalidProgramException("Apis not found");

            api.Map(app);
        }
    }

    public static void AddApi<TImplementation>(this IServiceCollection services)
        where TImplementation : class, IApi
    {
        services.AddTransient<IApi, TImplementation>();
    }
}
