using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CryptoData.Core.Interfaces
{
   public interface IBaseBL
    {
        IUnitOfWork RepositoryManager { get; set; }
        DbContext DB { get; }
        void RecreateDB();
    }
}
