using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KV.Test.Blockchain.Core.Interfaces;

public interface IFactory<TInstanceType>
{
    TInstanceType CreateNew(Action<TInstanceType> instanceOptions);
}
