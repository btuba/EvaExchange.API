using EvaExchange.Core.Common;
using EvaExchange.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories.Impl
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private EvaDbContext _context;
        public WriteRepository(EvaDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            await SaveAsync();
            return entityEntry.State == EntityState.Added;
        }

        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();
    }
}
