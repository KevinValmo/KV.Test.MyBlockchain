using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace KV.Test.MyBlockchain.Services.Apis.Interfaces;

public interface IApi
{
    void Map(IEndpointRouteBuilder endpointRouteBuilder);
}
