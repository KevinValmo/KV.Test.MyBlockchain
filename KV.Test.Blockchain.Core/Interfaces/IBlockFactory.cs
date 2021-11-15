using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KV.Test.Blockchain.Core.Interfaces;

public interface IBlockFactory<out TBlock> : IFactory<TBlock>
    where TBlock: IBlock, new()
{
}
