using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoData.Core.Models
{
    public class CryptoCoin
    {
        public int Id { get; set; }
        public string CoinName { get; set; }
        public string PictureURI { get; set; }
        public double Price { get; set; }
        public double MarketCap { get; set; }
        public string Change24h { get; set; }
    }
}
