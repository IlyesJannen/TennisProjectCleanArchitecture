using Domain.PlayerStats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options)
        : base(options)
        { }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().OwnsOne(p => p.Country);
            modelBuilder.Entity<Player>().OwnsOne(p => p.Data);

            base.OnModelCreating(modelBuilder);
        }
    }
}
