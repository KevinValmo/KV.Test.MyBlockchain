using KV.Test.MyBlockchain.Core.Interfaces;
using KV.Test.MyBlockchain.Services.Apis.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

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
        endpointRouteBuilder.Map("api/block", MineBlock);
        endpointRouteBuilder.Map("api/blockchain", GetFullBlockchain);
        endpointRouteBuilder.Map("api/blockchain/validity", IsBlockchainValid);
    }

    public IResult MineBlock()
    {
        IBlock previousBlock = _blockchain.PreviousBlock;
        int proof = _blockchain.ProofOfWork(previousBlock.Proof);
        string previousHash = _blockchain.GetBlockHash(previousBlock);

        IBlock newBlock = _blockchain.CreateBlock(proof, previousHash);

        var response = new
        {
            Message = "Congratulations, you just mined a block!",
            Block = newBlock
        };

        return Results.Ok(response);
    }

    public IResult GetFullBlockchain()
    {
        List<IBlock> chain = _blockchain.Chain;
        var response = new
        {
            Chain = chain,
            Lenght = chain.Count
        };
        return Results.Ok(response);
    }

    public IResult IsBlockchainValid()
    {
        bool isValid = _blockchain.IsBlockchainValid();

        string message;

        if (isValid)
            message = "All good. The Blockchain is valid.";
        else
            message = "Houston, we have a problem. The Blockchain is not valid.";

        var result = new
        {
            IsValid = isValid,
            Message = message
        };

        return Results.Ok(result);
    }
}
