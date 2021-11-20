using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Test.Blockchain.Services.Apis.Interfaces;

public interface IApi
{
    List<string> Map(WebApplication app);
}
