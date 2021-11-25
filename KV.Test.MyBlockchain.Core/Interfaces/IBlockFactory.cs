using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KV.Test.MyBlockchain.Core.Interfaces;

public interface IBlockFactory<TBlock> : IFactory<TBlock>
    where TBlock : IBlock
{
}
