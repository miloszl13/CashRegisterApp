using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureData
{
    public class BillsDbContext:DbContext
    {
        public BillsDbContext(DbContextOptions<BillsDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Bill_Product> Bill_Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key
            modelBuilder.Entity<Bill_Product>().HasKey(bp => new { bp.Bill_number, bp.Product_id });
        }
    }
}
 