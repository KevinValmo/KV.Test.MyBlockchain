using Microsoft.AspNetCore.Mvc;

namespace KV.Test.Blockchain.Services.Apis;

[ApiController]
[Route("/api/blockchain")]
public class BlockchainController : ControllerBase
{
    [HttpGet("test")]
    public IResult GetResult()
    {
        return Results.Ok();
    }
}
