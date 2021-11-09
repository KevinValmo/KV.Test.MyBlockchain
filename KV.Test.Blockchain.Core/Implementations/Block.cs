using KV.Test.Blockchain.Core.Interfaces;

namespace KV.Test.Blockchain.Core.Implementations;

public class Block : IBlock
{
    public ulong Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public ulong Proof { get; set; }
    public HashCode PreviousHash { get; set; }
}
