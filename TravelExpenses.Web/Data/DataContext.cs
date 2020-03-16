using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Web.Data.Entities;

namespace TravelExpenses.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TravelEntity> Travels { get; set; }

        public DbSet<ExpenseEntity> Expenses { get; set; }


    }
}
