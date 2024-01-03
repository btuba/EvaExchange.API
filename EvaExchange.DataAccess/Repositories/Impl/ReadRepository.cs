using EvaExchange.Core.Common;
using EvaExchange.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories.Impl
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EvaDbContext _context;
        public ReadRepository(EvaDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        //public IQueryable<T> GetAll()
        //    => Table;

        public async Task<T> GetByIdAsync(int id)
            => await Table.FirstOrDefaultAsync(x => x.Id == id);

        //public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        //    => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<bool> IsExist(int id)
            => await Table.AnyAsync(x => x.Id == id);
    }
}
