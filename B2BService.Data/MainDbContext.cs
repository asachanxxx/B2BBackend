﻿using B2BService.Domain;
using B2BService.Domain.Comunication;
using B2BService.Domain.Coparate;
using B2BService.Domain.Inventory;
using B2BService.Domain.Sales;
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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WarrentyType> WarrentyType { get; set; }
        public DbSet<SupplierWarrenty> SupplierWarrenty { get; set; }
        public DbSet<SpecialProducts> SpecialProduct { get; set; }
        public DbSet<SpecMaster> SpecMaster { get; set; }
        public DbSet<SpecDetail> SpecDetail { get; set; }
        public DbSet<SpecItem> SpecItem { get; set; }
        public DbSet<SpecProductDetails> SpecProductDetails { get; set; }
        public DbSet<SpecGroups> SpecGroups { get; set; }


        public DbSet<SupplierProducts> SupplierProduct { get; set; }

        public DbSet<Level1> Level1 { get; set; }
        public DbSet<Level2> Level2 { get; set; }
        public DbSet<Level3> Level3 { get; set; }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Series> Series { get; set; }


        public DbSet<BestSellProduct> BestSellProduct { get; set; }
        public DbSet<NewArrivalProduct> NewArrivalProduct { get; set; }
        public DbSet<FeatureProducts> FeatureProducts { get; set; }
        public DbSet<SpecLevelDetails> SpecLevelDetails { get; set; }
        public DbSet<ProductRating> ProductRating { get; set; }
        

        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Approval> Approval { get; set; }

        public DbSet<DistrictJson> District { get; set; }
        public DbSet<CityJson> City { get; set; }
        public DbSet<BussinessTypesJson> BussinessType { get; set; }
        public DbSet<EmailConfirmations> EmailConfirmations { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }

        //Sales
        public DbSet<QuotationMaster> QuotationMaster { get; set; }
        public DbSet<QuotationDetails> QuotationDetails { get; set; }
        public DbSet<QuotationRevision> QuotationRevision { get; set; }
        public DbSet<SupplierOrderHeader> SupplierOrderHeader { get; set; }
        public DbSet<SupplierOrderDetails> SupplierOrderDetails { get; set; }

        public DbSet<OrgSerials> OrgSerials { get; set; }
        public DbSet<OrderPriceChange> OrderPriceChange { get; set; }
        public DbSet<OrderWarranty> OrderWarranty { get; set; }
        public DbSet<QuotationWarranty> QuotationWarranty { get; set; }



    }
}
