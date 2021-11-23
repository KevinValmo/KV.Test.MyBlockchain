using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace KV.Test.Blockchain.Services.Apis.Interfaces;

public interface IApi
{
    void Map(IEndpointRouteBuilder endpointRouteBuilder);
}
