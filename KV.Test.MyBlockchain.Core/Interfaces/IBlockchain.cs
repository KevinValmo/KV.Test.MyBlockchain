﻿using System;

namespace KV.Test.MyBlockchain.Core.Interfaces;

public interface IBlockchain
{
    IBlock GetPreviousBlock { get; }

    IBlock CreateBlock(ulong proof, HashCode previousHash);
    ulong ProofOfWork(ulong previousProof);
}