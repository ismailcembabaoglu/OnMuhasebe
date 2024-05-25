using Microsoft.EntityFrameworkCore;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Domain.Mappings;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Context
{
    public class OnMuhasebePsqlDbContext:DbContext
    {
        public OnMuhasebePsqlDbContext(DbContextOptions<OnMuhasebePsqlDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankMotion> BankMotions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup>CustomerGroups { get; set; }
        public virtual DbSet<CustomerUnderGroup> CustomerUnderGroups { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeMotion> EmployeeMotions { get; set; }
        public virtual DbSet<FastSale> FastSales { get; set; }
        public virtual DbSet<FastSaleGroup> FastSaleGroups { get; set; }
        public virtual DbSet<Kdv> Kdvs { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductMotion> ProductMotions { get; set; }
        public virtual DbSet<ProductUnderGroup> ProductUnderGroups { get; set; }
        public virtual DbSet<SafeBox> SafeBoxes { get; set; }
        public virtual DbSet<SafeBoxMotion> SafeBoxMotions { get; set; }
        public virtual DbSet<SpecialCode> SpecialCodes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //BankMotion ilişkiler
            modelBuilder.Entity<BankMotion>().HasOne(e => e.Bank).WithMany(e => e.BankMotions).HasForeignKey(e => e.BankId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankMotion>().HasOne(e => e.Customer).WithMany(e => e.BankMotions).HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.NoAction);

            //Customer İlişkiler
            modelBuilder.Entity<Customer>().HasOne(e => e.CustomerGroup).WithMany(e => e.Customers).HasForeignKey(e => e.CustomerGroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Customer>().HasOne(e => e.SpecialCode).WithMany(e => e.Customers).HasForeignKey(e => e.SpecialCodeId).OnDelete(DeleteBehavior.NoAction);

            //CustomerUnderGroup İlişkileri
            modelBuilder.Entity<CustomerUnderGroup>().HasOne(c => c.CustomerGroup).WithMany(c => c.CustomerUnderGroups).HasForeignKey(c => c.CustomerGroupId).OnDelete(DeleteBehavior.NoAction);

            //Discount İlişkiler
            modelBuilder.Entity<Discount>().HasOne(e => e.Product).WithMany(e => e.Discounts).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);

            //EmployeeMotion İlişkiler
            modelBuilder.Entity<EmployeeMotion>().HasOne(e => e.Employee).WithMany(e => e.EmployeeMotions).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);

            //FastSale İlişkiler
            modelBuilder.Entity<FastSale>().HasOne(e => e.FastSaleGroup).WithMany(e => e.FastSales).HasForeignKey(e => e.FastSaleGroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FastSale>().HasOne(e => e.Product).WithMany(e =>e.FastSales).HasForeignKey(e =>e.ProductId).OnDelete(DeleteBehavior.NoAction);

            //Price İlişkiler
            modelBuilder.Entity<Price>().HasOne(e => e.Product).WithMany(e => e.Prices).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Price>().HasOne(e => e.Kdv).WithMany(e => e.Prices).HasForeignKey(e => e.KdvId).OnDelete(DeleteBehavior.NoAction);

            //Product İlişkiler
            modelBuilder.Entity<Product>().HasOne(e => e.Unit).WithMany(e => e.Products).HasForeignKey(e => e.UnitId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasOne(e => e.ProductGroup).WithMany(e => e.Products).HasForeignKey(e => e.ProductGroupId).OnDelete(DeleteBehavior.NoAction);

            //ProductMotion İlişkiler
            modelBuilder.Entity<ProductMotion>().HasOne(e => e.Product).WithMany(e => e.ProductMotions).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductMotion>().HasOne(e => e.Kdv).WithMany(e => e.ProductMotions).HasForeignKey(e => e.KdvId).OnDelete(DeleteBehavior.NoAction);

            //ProductUnderGroup İlişkiler
            modelBuilder.Entity<ProductUnderGroup>().HasOne(e => e.ProductGroup).WithMany(e => e.ProductUnderGroups).HasForeignKey(e => e.ProductGroupId).OnDelete(DeleteBehavior.NoAction);
           
            //SafeBoxMotion İlişkiler
            modelBuilder.Entity<SafeBoxMotion>().HasOne(e => e.SafeBox).WithMany(e => e.SafeBoxMotions).HasForeignKey(e => e.SafeBoxId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SafeBoxMotion>().HasOne(e => e.PaymentType).WithMany(e => e.SafeBoxMotions).HasForeignKey(sb => sb.PaymentTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SafeBoxMotion>().HasOne(e => e.Customer).WithMany(e => e.SafeBoxMotions).HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.NoAction);

            //SpecialCode İlişkiler
            modelBuilder.Entity<SpecialCode>().HasOne(e => e.Product).WithMany(e => e.SpecialCodes).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);

            //Voucher İlişkiler
            modelBuilder.Entity<Voucher>().HasOne(e => e.Customer).WithMany(e => e.Vouchers).HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Voucher>().HasOne(e => e.Bank).WithMany(e => e.Vouchers).HasForeignKey(e => e.BankId).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BaseModel>().UseTpcMappingStrategy();
            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new BankMotionMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerGroupMap());
            modelBuilder.ApplyConfiguration(new CustomerUnderGroupMap());
            modelBuilder.ApplyConfiguration(new DiscountMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new EmployeeMotionMap());
            modelBuilder.ApplyConfiguration(new FastSaleGroupMap());
            modelBuilder.ApplyConfiguration(new FastSaleMap());
            modelBuilder.ApplyConfiguration(new KdvMap());
            modelBuilder.ApplyConfiguration(new PaymentTypeMap());
            modelBuilder.ApplyConfiguration(new PriceMap());
            modelBuilder.ApplyConfiguration(new ProductGroupMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductMotionMap());
            modelBuilder.ApplyConfiguration(new ProducUnderGroupMap());
            modelBuilder.ApplyConfiguration(new SafeBoxMap());
            modelBuilder.ApplyConfiguration(new SafeBoxMotionMap());
            modelBuilder.ApplyConfiguration(new SpecialCodeMap());
            modelBuilder.ApplyConfiguration(new UnitMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VoucherMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
