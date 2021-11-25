using KV.Test.MyBlockchain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace KV.Test.MyBlockchain.Core.Implementations;

public class Blockchain : IBlockchain
{
    public IBlockFactory<IBlock> BlockFactory { get; }

    public Blockchain(IBlockFactory<IBlock> blockFactory)
    {
        BlockFactory = blockFactory;
    }

    public IBlock CreateBlock(ulong proof, HashCode previousHash)
    {
        IBlock block = BlockFactory.CreateNew(b =>
        {
            b.Index = (ulong)chain.Count + 1;
            b.TimeStamp = DateTime.UtcNow;
            b.Proof = proof;
            b.PreviousHash = previousHash;
        });

        return block;
    }

    private readonly List<IBlock> chain = new();

    public IBlock GetPreviousBlock { get { return chain[^1]; } }

    public ulong ProofOfWork(ulong previousProof)
    {
        ulong newProof = 1;
        bool checkProof = false;

        while (checkProof == false)
        {
            ulong toBeWork = newProof ^ 2 - previousProof ^ 2;

            using SHA256 sha256 = SHA256.Create();
            byte[] hashOperation = sha256.ComputeHash(BitConverter.GetBytes(toBeWork));
            if (hashOperation[..4].ToString() == "0000")
                checkProof = true;
            else
                newProof += 1;
        }

        return newProof;
    }

}
