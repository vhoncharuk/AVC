using AVC.DB.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVC.DB.Domain.Entities;

namespace AVC.DB.Domain
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public DbSet<Category> Category { get; set; }
       

        public ProductDbContext()
			: base("DefaultConnection")
        {
        }

        public ProductDbContext(string connString)
            : base(connString)
        {
        }

        public static ProductDbContext Create()
        {
            return new ProductDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryConfigurations());
            modelBuilder.Configurations.Add(new ProductsConfigurations());
            
        }
    }
}
