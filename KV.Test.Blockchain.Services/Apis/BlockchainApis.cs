using KV.Test.Blockchain.Core.Interfaces;
using KV.Test.Blockchain.Services.Apis.Extensions;
using KV.Test.Blockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace KV.Test.Blockchain.Services.Apis;

public class BlockchainApis : IBlockchainApis, IApi
{
    public IBlockchain _blockchain;

    public BlockchainApis(IBlockchain? blockchain)
    {
        ArgumentNullException.ThrowIfNull(blockchain);

        _blockchain = blockchain;
    }

    public void Map(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.Map("api/blockchain/getresult", GetResult);
    }

    public IResult GetResult()
    {
        IBlock block = _blockchain.CreateBlock(1, new HashCode());
        return Results.Ok(block);
    }
}
