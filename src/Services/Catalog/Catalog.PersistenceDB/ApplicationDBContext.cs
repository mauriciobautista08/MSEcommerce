using Catalog.Domain;
using Catalog.PersistenceDB.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.PersistenceDB
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfiguration(builder);
        }

        private void ModelConfiguration(ModelBuilder builder)
        {
            new ProductConfiguration(builder.Entity<Product>());
            new ProductInStockConfiguration(builder.Entity<ProductInStock>());
        }

    }
}
