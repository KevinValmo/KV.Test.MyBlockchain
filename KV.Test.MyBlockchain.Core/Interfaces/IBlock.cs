using System;

namespace KV.Test.MyBlockchain.Core.Interfaces;

public interface IBlock
{
    public ulong Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public int Proof { get; set; }
    public string PreviousHash { get; set; }
}
