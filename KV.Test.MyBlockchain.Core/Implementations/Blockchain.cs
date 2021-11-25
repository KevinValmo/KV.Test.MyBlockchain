﻿using KV.Test.MyBlockchain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace KV.Test.MyBlockchain.Core.Implementations;

public class Blockchain : IBlockchain
{
    private readonly IBlockFactory<IBlock> _blockFactory;
    private readonly JsonSerializerOptions jsonSerializerOptions = new();
    private readonly Func<byte[], byte[]> computeHash;

    public List<IBlock> Chain { get; private set; } = new();
    public IBlock PreviousBlock { get { return Chain[^1]; } }

    public Blockchain(IBlockFactory<IBlock> blockFactory)
    {
        _blockFactory = blockFactory;
        SHA256 sha256 = SHA256.Create();
        computeHash = sha256.ComputeHash;

        // Genesis block
        CreateBlock(1, "0");
    }

    public string GetBlockHash(IBlock block)
    {
        string hash;

        string serializedBlock = JsonSerializer.Serialize(block, jsonSerializerOptions);

        byte[] hashBytes = computeHash(Encoding.Unicode.GetBytes(serializedBlock));

        hash = Convert.ToHexString(hashBytes);

        return hash;
    }

    public IBlock CreateBlock(int proof, string previousHash)
    {
        IBlock block = _blockFactory.CreateNew(b =>
        {
            b.Index = (ulong)Chain.Count + 1;
            b.TimeStamp = DateTime.UtcNow;
            b.Proof = proof;
            b.PreviousHash = previousHash;
        });

        Chain.Add(block);

        return block;
    }

    public int ProofOfWork(int previousProof)
    {
        int newProof = 1;
        bool checkProof = false;

        while (checkProof == false)
        {
            int workResult = Work(previousProof, newProof);

            byte[] hashOperation = computeHash(BitConverter.GetBytes(workResult));
            string hash = Convert.ToHexString(hashOperation);
            if (hash[..4] == "0000")
                checkProof = true;
            else
                newProof += 1;
        }

        return newProof;
    }

    private int Work(int arg1, int arg2)
    {
        return arg2 ^ 2 - arg1 ^ 2;
    }

    public bool IsBlockchainValid()
    {
        if (Chain.Count <= 1)
            return true;

        int blockIndex = 0;
        IBlock previousBlock = Chain[blockIndex];
        blockIndex++;

        while (blockIndex < Chain.Count)
        {
            IBlock currentBlock = Chain[blockIndex];
            if (currentBlock.PreviousHash != GetBlockHash(previousBlock))
                return false;

            int workResult = Work(previousBlock.Proof, currentBlock.Proof);

            byte[] hashOperation = computeHash(BitConverter.GetBytes(workResult));
            string hash = Convert.ToHexString(hashOperation);
            if (hash[..4] != "0000")
                return false;

            previousBlock = currentBlock;
            blockIndex++;
        }
        return true;
    }

}
