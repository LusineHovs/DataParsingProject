using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoData.Core.Interfaces;
using CryptoData.BLL.Logic;


namespace CryptoData.BLL.BLFactory
{
   public class BLFactory : IBLFactory
    {

        public BLFactory()
        {
        }

        public ICryptoCoinBL CreateCryptoCoinBL(IBaseBL parentBL = null)
        {
            return new CryptoCoinBL(parentBL);
        }
    }
}
