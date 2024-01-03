using EvaExchange.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
       // Task<bool> RemoveAsync(int id);
       // bool Update(T entity);
        Task<int> SaveAsync();
    }
}
