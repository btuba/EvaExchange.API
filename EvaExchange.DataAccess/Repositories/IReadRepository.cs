using EvaExchange.Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
        Task<bool> IsExist(int id);
    }


}
