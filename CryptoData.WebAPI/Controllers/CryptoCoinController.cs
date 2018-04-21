using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CryptoData.Core.Interfaces;
using CryptoData.BLL.Logic;
using System.Threading.Tasks;

namespace CryptoData.WebAPI.Controllers
{
    public class CryptoCoinController : BaseController
    {
        
        public async Task<IHttpActionResult> Get()
        {
            List<CryptoData.Core.CryptoCoin> coinList = new List<Core.CryptoCoin>();
            ICryptoCoinBL bl = this.blFactory.CreateCryptoCoinBL();
            coinList = await bl.GetAllCryptoCoins();
            if (!coinList.Any())
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(coinList);
        }

        public async Task<IHttpActionResult> GetById(int id)
        {
            var coin = new CryptoData.Core.CryptoCoin();
            ICryptoCoinBL bl = this.blFactory.CreateCryptoCoinBL();
            coin = await bl.GetCryptoCoin(id);
            if (coin == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(coin);

        }

        
        public async Task<IHttpActionResult> Post()
        {
            ICryptoCoinBL bl = this.blFactory.CreateCryptoCoinBL();
            await bl.AddCryptoCoinRange();
            return StatusCode(HttpStatusCode.Created);
        }

        

        public async Task<IHttpActionResult> Delete(int id)
        {
            ICryptoCoinBL bl = this.blFactory.CreateCryptoCoinBL();
            var coin =await bl.GetCryptoCoin(id);
            if (coin==null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            await bl.DeleteCryptoCoin(coin);
            return StatusCode(HttpStatusCode.OK);

        }
    }
}
