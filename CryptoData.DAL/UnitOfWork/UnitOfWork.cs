using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoData.Core.Models;
using System.Net;
using System.Text.RegularExpressions;
using CryptoData.DAL;
using CryptoData.Core.Interfaces;
using System.Data.Entity;

namespace CryptoData.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;
        private CryptoCoinRepository _cryptoCoins;

        public UnitOfWork(DbContext context)
        {
            if (context==null)
            {
                throw new ArgumentNullException("argument wasn't supplied");
            }

            _context = context;
        }

        // instatiates the repository
      public IRepository<CryptoData.Core.CryptoCoin> CryptoCoins
        {
            get
            {
                if (_cryptoCoins==null)
                {
                    _cryptoCoins = new CryptoCoinRepository(_context);
                }
                return _cryptoCoins;
            }
        }



        public void Save()
        {
            _context.SaveChanges();
        }

        #region Logic
        //public static List<CryptoCoin> list { get; set; }
        //public List<CryptoCoin> ParsingCryptoCoin()
        //{
        //    //var watch = System.Diagnostics.Stopwatch.StartNew();

        //    list = new List<CryptoCoin>();
        //    ServicePointManager.Expect100Continue = true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    for (int i = 1; i <= 61; i++)
        //    {
        //        string uri = @"https://coinranking.com/?page=" + i;

        //        var client = new System.Net.WebClient();
        //        var content = client.DownloadString(uri);
        //        HtmlAgilityPack.HtmlDocument document = new HtmlDocument();
        //        document.LoadHtml(content);

        //        //Html selector / XPath
        //        var value = document.DocumentNode.SelectSingleNode(".//div[@class='coin-list__body']");
        //        var htmlNode = value.SelectNodes(".//a[@class='coin-list__body__row']").ToList();

        //        //
        //        foreach (var item in htmlNode)
        //        {
        //            var elementId = Convert.ToInt32(item.SelectSingleNode(".//span[@class='coin-list__body__row__cryptocurrency__prepend__rank']").InnerText);
        //            string elementImg = null;
        //            var img = item.SelectSingleNode(".//img[@class='coin-list__body__row__cryptocurrency__prepend__icon__img']");
        //            if (img != null)
        //            {
        //                elementImg = img.GetAttributeValue("src", "default");
        //            }
        //            var elementName = item.SelectSingleNode(".//span[@class='coin-name']").InnerText;
        //            var elementPrice = Convert.ToDouble(item.SelectSingleNode(".//span[@class='coin-list__body__row__price__value']").InnerText);
        //            var elementMarketCap = Convert.ToDouble(item.SelectSingleNode(".//span[@class='coin-list__body__row__market-cap__value']").InnerText);

        //            var change = item.SelectSingleNode(".//span[@class='coin-list__body__row__change coin-list__body__row__change--negative']");
        //            if (change != null)
        //            {
        //                var elementChange = Convert.ToString(Regex.Split(change.FirstChild.InnerText, @"[^0-9\.]+").Where(a => !string.IsNullOrEmpty(a)).First());
        //                list.Add(new CryptoCoin()
        //                {
        //                    Id = elementId,
        //                    CoinName = elementName,
        //                    PictureURI = elementImg,
        //                    Price = elementPrice,
        //                    MarketCap = elementMarketCap,
        //                    Change24h = "-" + elementChange
        //                });
        //            }

        //            var changeRepl = item.SelectSingleNode(".//span[@class='coin-list__body__row__change']");
        //            if (changeRepl != null)
        //            {
        //                var elementChangeRepl = Convert.ToString(Regex.Split(changeRepl.FirstChild.InnerText, @"[^0-9\.]+").Where(a => !string.IsNullOrEmpty(a)).First());
        //                list.Add(new CryptoCoin()
        //                {
        //                    Id = elementId,
        //                    CoinName = elementName,
        //                    PictureURI = elementImg,
        //                    Price = elementPrice,
        //                    MarketCap = elementMarketCap,
        //                    Change24h = "+" + elementChangeRepl
        //                });
        //            }
        //        }
        //    }

        //    //watch.Stop();
        //    //var elapsedMs = watch.ElapsedMilliseconds;
        //    //return elapsedMs;

        //    return list;
        //}
        #endregion
    }
}
