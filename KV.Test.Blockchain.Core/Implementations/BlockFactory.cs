using KV.Test.Blockchain.Core.Interfaces;
using System;

namespace KV.Test.Blockchain.Core.Implementations;

public class BlockFactory : IBlockFactory<IBlock>
{
    public IBlock CreateNew(Action<IBlock> instanceOptions)
    {
        IBlock block = new Block();
        instanceOptions(block);
        return block;
    }
}
