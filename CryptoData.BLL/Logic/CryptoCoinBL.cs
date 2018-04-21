using CryptoData.Core;
using CryptoData.Core.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoData.BLL.Logic
{
   public class CryptoCoinBL :BaseBL, ICryptoCoinBL
    {
        public CryptoCoinBL(IBaseBL parentBL) :
            base(parentBL)
        {
            
        }

        public async Task<CryptoData.Core.CryptoCoin> GetCryptoCoin(int id)
        {
            var coin =await base.RepositoryManager.CryptoCoins.Get(id);
            return coin;
        }
        public async Task<List<CryptoData.Core.CryptoCoin>> GetAllCryptoCoins()
        {
            var coins =await base.RepositoryManager.CryptoCoins.GetAllAsync();
            return coins.ToList();
        }
        public async Task AddCryptoCoinRange()
        {
            Parser();
           await base.RepositoryManager.CryptoCoins.AddRange(list);
        }
        public async Task DeleteCryptoCoin(CryptoData.Core.CryptoCoin coin)
        {
           await base.RepositoryManager.CryptoCoins.Delete(coin);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        #region ParsingLogic
        public static List<CryptoCoin> list { get; set; }
        public void Parser()
        {

            list = new List<CryptoCoin>();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            for (int i = 1; i <= 61; i++)
            {
                string uri = @"https://coinranking.com/?page=" + i;

                var client = new System.Net.WebClient();
                var content = client.DownloadString(uri);
                HtmlAgilityPack.HtmlDocument document = new HtmlDocument();
                document.LoadHtml(content);

                //Html selector / XPath
                var value = document.DocumentNode.SelectSingleNode(".//div[@class='coin-list__body']");
                var htmlNode = value.SelectNodes(".//a[@class='coin-list__body__row']").ToList();

                //
                foreach (var item in htmlNode)
                {
                    var elementId = Convert.ToInt32(item.SelectSingleNode(".//span[@class='coin-list__body__row__cryptocurrency__prepend__rank']").InnerText);
                    string elementImg = null;
                    var img = item.SelectSingleNode(".//img[@class='coin-list__body__row__cryptocurrency__prepend__icon__img']");
                    if (img != null)
                    {
                        elementImg = img.GetAttributeValue("src", "default");
                    }
                    var elementName = item.SelectSingleNode(".//span[@class='coin-name']").InnerText;
                    var elementPrice = Convert.ToDouble(item.SelectSingleNode(".//span[@class='coin-list__body__row__price__value']").InnerText);
                    var elementMarketCap = Convert.ToDouble(item.SelectSingleNode(".//span[@class='coin-list__body__row__market-cap__value']").InnerText);

                    var change = item.SelectSingleNode(".//span[@class='coin-list__body__row__change coin-list__body__row__change--negative']");
                    if (change != null)
                    {
                        var elementChange = Convert.ToString(Regex.Split(change.FirstChild.InnerText, @"[^0-9\.]+").Where(a => !string.IsNullOrEmpty(a)).First());
                        list.Add(new CryptoCoin()
                        {
                            Id = elementId,
                            CoinName = elementName,
                            PictureURI = elementImg,
                            UnitPrice = elementPrice,
                            MarketCap = elementMarketCap,
                            Change24h = "-" + elementChange
                        });
                    }

                    var changeRepl = item.SelectSingleNode(".//span[@class='coin-list__body__row__change']");
                    if (changeRepl != null)
                    {
                        var elementChangeRepl = Convert.ToString(Regex.Split(changeRepl.FirstChild.InnerText, @"[^0-9\.]+").Where(a => !string.IsNullOrEmpty(a)).First());
                        list.Add(new CryptoCoin()
                        {
                            Id = elementId,
                            CoinName = elementName,
                            PictureURI = elementImg,
                            UnitPrice = elementPrice,
                            MarketCap = elementMarketCap,
                            Change24h = "+" + elementChangeRepl
                        });
                    }
                }
            }


            //return list;
        }
#endregion
    }
}
