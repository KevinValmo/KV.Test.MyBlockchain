using System;
using System.Collections.Generic;

namespace KV.Test.MyBlockchain.Core.Interfaces;

public interface IBlockchain
{
    IBlock PreviousBlock { get; }
    List<IBlock> Chain { get; }

    IBlock CreateBlock(int proof, string previousHash);
    string GetBlockHash(IBlock block);
    int ProofOfWork(int previousProof);
    bool IsBlockchainValid();
}
