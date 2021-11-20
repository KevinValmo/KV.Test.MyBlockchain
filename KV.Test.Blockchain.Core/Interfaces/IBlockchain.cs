using System;

namespace KV.Test.Blockchain.Core.Interfaces;

public interface IBlockchain
{
    IBlock GetPreviousBlock { get; }

    IBlock CreateBlock(ulong proof, HashCode previousHash);
    ulong ProofOfWork(ulong previousProof);
}
