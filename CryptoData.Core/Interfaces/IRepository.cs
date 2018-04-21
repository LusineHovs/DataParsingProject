using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoData.Core.Interfaces
{
   public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddRange(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);

    }
}
