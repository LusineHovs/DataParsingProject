using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoData.Core.Interfaces
{
   public interface IBLFactory
    {
        ICryptoCoinBL CreateCryptoCoinBL(IBaseBL parentBL = null);
    }
}
