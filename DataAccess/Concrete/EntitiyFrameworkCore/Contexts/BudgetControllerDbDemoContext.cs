using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFrameworkCore.Contexts
{
    public class BudgetControllerDbDemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDb;Database=BudgetControllerDbDemo;Trusted_Connection=True");
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<PaymentType>? PaymentTypes { get; set; }
        public DbSet<Receipt>? Receipts { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }
    }
}
