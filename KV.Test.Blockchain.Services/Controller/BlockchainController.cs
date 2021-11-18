using KV.Test.Blockchain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KV.Test.Blockchain.Services.Apis;

[ApiController]
[Route("/api/blockchain")]
public class BlockchainController : ControllerBase
{
    public BlockchainController(IBlockchain blockchain)
    {
        Blockchain = blockchain;
    }

    public IBlockchain Blockchain { get; }

    [HttpGet("test")]
    [Produces("application/json", Type=typeof(IBlock))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IResult GetResult()
    {
        IBlock block = Blockchain.CreateBlock(1, new HashCode());
        return Results.Json(block);
    }
}
