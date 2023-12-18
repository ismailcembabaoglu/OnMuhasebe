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
            //Bank İlişliler
            modelBuilder.Entity<Bank>().HasMany(b => b.BankMotions).WithOne(bm => bm.Bank).HasForeignKey(bm => bm.BankId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Bank>().HasMany(b => b.Vouchers).WithOne(v => v.Bank).HasForeignKey(v => v.BankId).OnDelete(DeleteBehavior.Cascade);

            //BankMotion ilişkiler
            modelBuilder.Entity<BankMotion>().HasOne(bm => bm.Bank).WithMany(b => b.BankMotions).HasForeignKey(bm => bm.BankId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BankMotion>().HasOne(bm => bm.Customer).WithMany(c => c.BankMotions).HasForeignKey(bm => bm.CustomerId).OnDelete(DeleteBehavior.Restrict);

            //Customer İlişkiler
            modelBuilder.Entity<Customer>().HasMany(c => c.BankMotions).WithOne(bm => bm.Customer).HasForeignKey(bm => bm.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>().HasMany(c => c.Vouchers).WithOne(v => v.Customer).HasForeignKey(v => v.CustomerId).OnDelete(DeleteBehavior.Cascade);

            //Employee İlişkiler
            modelBuilder.Entity<Employee>().HasMany(e => e.EmployeeMotions).WithOne(em => em.Employee).HasForeignKey(em => em.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            //EmployeeMotion İlişkiler
            modelBuilder.Entity<EmployeeMotion>().HasOne(em => em.Employee).WithMany(e => e.EmployeeMotions).HasForeignKey(em => em.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            //Kdv İlişkiler
            modelBuilder.Entity<Kdv>().HasMany(k => k.Prices).WithOne(p => p.Kdv).HasForeignKey(p => p.KdvId).OnDelete(DeleteBehavior.Cascade);

            //PaymentType İlişkiler
            modelBuilder.Entity<PaymentType>().HasMany(pt => pt.SafeBoxMotions).WithOne(sb => sb.PaymentType).HasForeignKey(sb => sb.PaymentTypeId).OnDelete(DeleteBehavior.Cascade);

            //Price İlişkiler
            modelBuilder.Entity<Price>().HasOne(p => p.Product).WithMany(p => p.Prices).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Price>().HasOne(p => p.Kdv).WithMany(k => k.Prices).HasForeignKey(p => p.KdvId).OnDelete(DeleteBehavior.Restrict);

            //Product İlişkiler
            modelBuilder.Entity<Product>().HasOne(p => p.ProductGroup).WithMany(pg => pg.Products).HasForeignKey(p => p.ProductGroupId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(p => p.SpecialCodes).WithOne(sc => sc.Product).HasForeignKey(sc => sc.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(p => p.Prices).WithOne(pr => pr.Product).HasForeignKey(pr => pr.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(p => p.ProductMotions).WithOne(pm => pm.Product).HasForeignKey(pm => pm.ProductId).OnDelete(DeleteBehavior.Restrict);

            //ProductGroup İlişkiler
            modelBuilder.Entity<ProductGroup>().HasMany(pg => pg.Products).WithOne(p => p.ProductGroup).HasForeignKey(p => p.ProductGroupId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductGroup>().HasMany(pg => pg.ProductUnderGroups).WithOne(pug => pug.ProductGroup).HasForeignKey(pug => pug.ProductGroupId).OnDelete(DeleteBehavior.Restrict);

            //ProductMotion İlişkiler
            modelBuilder.Entity<ProductMotion>().HasOne(pm => pm.Product).WithMany(p => p.ProductMotions).HasForeignKey(pm => pm.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductMotion>().HasOne(pm => pm.Kdv).WithMany().HasForeignKey(pm => pm.KdvId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProductMotion>().HasOne(pm => pm.Warehouse).WithMany(w => w.ProductMotions).HasForeignKey(pm => pm.WarehouseId).OnDelete(DeleteBehavior.Restrict);

            //ProductUnderGroup İlişkiler
            modelBuilder.Entity<ProductUnderGroup>().HasOne(pug => pug.ProductGroup).WithMany(pg => pg.ProductUnderGroups).HasForeignKey(pug => pug.ProductGroupId).OnDelete(DeleteBehavior.Restrict);

            //SafeBox İlişkiler
            modelBuilder.Entity<SafeBox>().HasMany(sb => sb.SafeBoxMotions).WithOne(sbm => sbm.SafeBox).HasForeignKey(sb => sb.SafeBoxId).OnDelete(DeleteBehavior.Cascade);

            //SafeBoxMotion İlişkiler
            modelBuilder.Entity<SafeBoxMotion>().HasOne(sb => sb.SafeBox).WithMany(s => s.SafeBoxMotions).HasForeignKey(sb => sb.SafeBoxId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SafeBoxMotion>().HasOne(sb => sb.PaymentType).WithMany(pt => pt.SafeBoxMotions).HasForeignKey(sb => sb.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);

            //SpecialCode İlişkiler
            modelBuilder.Entity<SpecialCode>().HasOne(sc => sc.Product).WithMany(p => p.SpecialCodes).HasForeignKey(sc => sc.ProductId).OnDelete(DeleteBehavior.Restrict);

            //Voucher İlişkiler
            modelBuilder.Entity<Voucher>().HasOne(v => v.Customer).WithMany(c => c.Vouchers).HasForeignKey(v => v.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Voucher>().HasOne(v => v.Bank).WithMany(b => b.Vouchers).HasForeignKey(v => v.BankId).OnDelete(DeleteBehavior.Restrict);

            //Warehouse İlişkiler
            modelBuilder.Entity<Warehouse>().HasMany(w => w.ProductMotions).WithOne(pm => pm.Warehouse).HasForeignKey(pm => pm.WarehouseId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<BaseModel>().UseTpcMappingStrategy();
            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new BankMotionMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
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
