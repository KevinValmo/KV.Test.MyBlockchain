using KV.Test.MyBlockchain.Core.Interfaces;
using System;

namespace KV.Test.MyBlockchain.Core.Implementations;

public class Block : IBlock
{
    public ulong Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public ulong Proof { get; set; }
    public HashCode PreviousHash { get; set; }
}
