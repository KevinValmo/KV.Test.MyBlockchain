using KV.Test.Blockchain.Core.Interfaces;
using KV.Test.Blockchain.Services.Apis.Extensions;
using KV.Test.Blockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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

    public List<string> Map(WebApplication app)
    {
        List<string> apis = new List<string>
        {
            app.MapApi("api/blockchain/getresult", GetResult)
        };

        return apis;
    }

    public IResult GetResult()
    {
        IBlock block = _blockchain.CreateBlock(1, new HashCode());
        return Results.Ok(block);
    }
}
