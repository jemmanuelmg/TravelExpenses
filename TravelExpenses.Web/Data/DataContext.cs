using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Web.Data.Entities;

namespace TravelExpenses.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TravelEntity> Travels { get; set; }

        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TravelEntity>()
                .HasIndex(t => t.Id)
                .IsUnique();

            builder.Entity<ExpenseEntity>()
                .HasIndex(e => e.Id)
                .IsUnique();

            builder.Entity<ExpenseTypeEntity>()
                .HasIndex(et => et.Id)
                .IsUnique();
        }



    }
}
