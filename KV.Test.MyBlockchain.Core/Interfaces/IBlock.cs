﻿using System;

namespace KV.Test.MyBlockchain.Core.Interfaces;

public interface IBlock
{
    public ulong Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public ulong Proof { get; set; }
    public HashCode PreviousHash { get; set; }
}