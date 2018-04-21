using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoData.Core.Interfaces
{
    public interface ICryptoCoinBL
    {
        Task<CryptoCoin> GetCryptoCoin(int id);
        Task<List<CryptoCoin>> GetAllCryptoCoins();
        Task AddCryptoCoinRange();
        Task DeleteCryptoCoin(CryptoCoin coin);
    }
}
