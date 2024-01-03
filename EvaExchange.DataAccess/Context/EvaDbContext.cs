using EvaExchange.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Context
{
    public class EvaDbContext : DbContext
    {
        DbSet<Client>? Clients { get; set; }
        DbSet<Transaction>? Transactions { get; set; }
        DbSet<Share>? Shares { get; set; }
        DbSet<Price>? Prices { get; set; }
        DbSet<Portfolio>? Portfolios { get; set; }

        public EvaDbContext(DbContextOptions<EvaDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, UserName = "client1", },
                new Client { Id = 2, UserName = "client2", },
                new Client { Id = 3, UserName = "client3", },
                new Client { Id = 4, UserName = "client4", },
                new Client { Id = 5, UserName = "client5", }
                );

            modelBuilder.Entity<Share>(entity =>
            {
                entity.HasIndex(e => e.Symbol).IsUnique();
            });

            modelBuilder.Entity<Share>().HasData(
                new Share { Id = 1, Symbol = "AAA" },
                new Share { Id = 2, Symbol = "BBB" },
                new Share { Id = 3, Symbol = "CCC" },
                new Share { Id = 4, Symbol = "DDD" },
                new Share { Id = 5, Symbol = "EEE" }
            );

            modelBuilder.Entity<Price>().HasData(
                new Price { Id = 1, Rate = 10, ShareId = 1 },
                new Price { Id = 2, Rate = 15, ShareId = 1, CreatedDate = DateTime.UtcNow },
                new Price { Id = 3, Rate = 1, ShareId = 2 },
                new Price { Id = 4, Rate = 5, ShareId = 3 },
                new Price { Id = 5, Rate = 10, ShareId = 4 },
                new Price { Id = 6, Rate = 20, ShareId = 5 }
                );

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio { Id = 1, ClientId = 1 },
                new Portfolio { Id = 2, ClientId = 2 },
                new Portfolio { Id = 3, ClientId = 3 },
                new Portfolio { Id = 4, ClientId = 4 }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, PortfolioId = 1, Quantity = 10, Rate = 10, ShareId = 1, Action = "Buy" },
                new Transaction { Id = 2, PortfolioId = 1, Quantity = 5, Rate = 10, ShareId = 1, Action = "Sell" },
                new Transaction { Id = 3, PortfolioId = 2, Quantity = 10, Rate = 10, ShareId = 2, Action = "Buy" },
                new Transaction { Id = 4, PortfolioId = 2, Quantity = 1, Rate = 15, ShareId = 2, Action = "Sell" },
                new Transaction { Id = 5, PortfolioId = 3, Quantity = 1, Rate = 11, ShareId = 2, Action = "Sell" },
                new Transaction { Id = 6, PortfolioId = 3, Quantity = 10, Rate = 10, ShareId = 3, Action = "Buy" },
                new Transaction { Id = 7, PortfolioId = 4, Quantity = 10, Rate = 10, ShareId = 3, Action = "Buy" },
                new Transaction { Id = 8, PortfolioId = 4, Quantity = 2, Rate = 20, ShareId = 3, Action = "Sell" }
                );
        }

        protected override void ConfigureConventions(
        ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(10,2);
        }
    }
}
