using B2BService.Domain;
using B2BService.Domain.Comunication;
using B2BService.Domain.Coparate;
using B2BService.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Data
{
    public class MainDbContext:DbContext
    {
        public MainDbContext():base("SysConn")
        {

        }

        public DbSet<Organization> Organization { get; set; }
        public DbSet<SystemTasks> SystemTask { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SystemMessages> SystemMessages { get; set; }
        public DbSet<CateglogProducts> CateglogProducts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImages> ProductImage { get; set; }
        public DbSet<ProductReviews> ProductReview { get; set; }
        public DbSet<ProductSpecDetail> ProductSpecDetail { get; set; }
        public DbSet<ProductWarrenty> ProductWarrenty { get; set; }
        public DbSet<SpecialProducts> SpecialProduct { get; set; }
        public DbSet<SpecMaster> SpecMaster { get; set; }
        public DbSet<SupplierProducts> SupplierProduct { get; set; }

        public DbSet<Level1> Level1 { get; set; }
        public DbSet<Level2> Level2 { get; set; }
        public DbSet<Level3> Level3 { get; set; }
    }
}
