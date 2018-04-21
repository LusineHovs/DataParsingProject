using CryptoData.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoData.DAL
{
    class CryptoCoinRepository : Repository<CryptoCoin>
    {
        public CryptoCoinRepository(DbContext context): base(context)
        {

        }
    }
}
