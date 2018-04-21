using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using CryptoData.BLL.BLFactory;

namespace CryptoData.WebAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected BLFactory blFactory;
        public BaseController()
        {
            blFactory = new BLFactory();
        }
    }
}
