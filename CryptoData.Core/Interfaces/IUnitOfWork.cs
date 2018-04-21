using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoData.Core.Models;

namespace CryptoData.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<CryptoCoin> CryptoCoins { get; }
        void Save();
    }
}
