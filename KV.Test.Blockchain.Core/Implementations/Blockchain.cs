using KV.Test.Blockchain.Core.Interfaces;
using System.Security.Cryptography;

namespace KV.Test.Blockchain.Core.Implementations;

public class Blockchain: IBlockchain
{
    private List<IBlock> chain = new();

    public Blockchain()
    {

    }

    public IBlock CreateBlock(ulong proof, HashCode previousHash)
    {
        // do we need a factory for creating a new block?
        //IBlock block = new TBlock
        //{
        //    Index = (ulong)chain.Count + 1,
        //    TimeStamp = DateTime.UtcNow,
        //    Proof = proof,
        //    PreviousHash = previousHash
        //};

        return new Block();
    }

    public IBlock GetPreviousBlock { get { return chain[^1]; } }

    public ulong ProofOfWork(ulong previousProof)
    {
        ulong newProof = 1;
        bool checkProof = false;

        while(checkProof == false)
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
