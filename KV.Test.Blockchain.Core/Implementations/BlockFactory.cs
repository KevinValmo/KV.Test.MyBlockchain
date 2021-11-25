using KV.Test.MyBlockchain.Core.Interfaces;
using System;

namespace KV.Test.MyBlockchain.Core.Implementations;

public class BlockFactory : IBlockFactory<IBlock>
{
    public IBlock CreateNew(Action<IBlock> instanceOptions)
    {
        IBlock block = new Block();
        instanceOptions(block);
        return block;
    }
}
