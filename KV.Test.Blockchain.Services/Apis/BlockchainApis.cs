using KV.Test.MyBlockchain.Core.Interfaces;
using KV.Test.MyBlockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace KV.Test.MyBlockchain.Services.Apis;

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
