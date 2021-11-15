using KV.Test.Blockchain.Core.Interfaces;

namespace KV.Test.Blockchain.Core.Implementations;

public class BlockFactory<TBlock> : IBlockFactory<TBlock>
    where TBlock : Block, new()
{
    public TBlock CreateNew()
    {
        return new TBlock();
    }
}
