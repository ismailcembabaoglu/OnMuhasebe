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
    public class OnMuhasebePsqlDbContext : DbContext
    {
        public OnMuhasebePsqlDbContext(DbContextOptions<OnMuhasebePsqlDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankMotion> BankMotions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
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

        private void Seed(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("822E044B-5656-4B44-AD0F-01D7761E2CBE"),
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin",
                Email = "icb1742@gmail.com",
                Password = "17421742",
                FirstName = "Süper",
                LastName = "Admin",
                IsActive = true,

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("C326EE05-4878-4219-958D-AD3CAEFA4E11"),
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin",
                Email = "eagledenizcilik@outlook.com.tr",
                Password = "Eagle0204.",
                FirstName = "Alican",
                LastName = "Kartal",
                IsActive = true,

            });
            modelBuilder.Entity<ProductGroup>().HasData(new ProductGroup
            {
                Id = Guid.Parse("3342D171-222F-48BD-901D-17FB7E48D4EB"),
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin",
                ProductGroupName = "Grupsuz"
            });
            modelBuilder.Entity<ProductUnderGroup>().HasData(new ProductUnderGroup
            {
                Id = Guid.Parse("C340B1D5-F2FE-4F0C-9D4F-511F78A8643C"),
                ProductGroupId = Guid.Parse("3342D171-222F-48BD-901D-17FB7E48D4EB"),
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin",
                ProductUnderGroupName = "Grupsuz"
            });
            modelBuilder.Entity<Unit>().HasData(new Unit
            {
                Id = Guid.Parse("BD703370-8093-4AA3-9DA6-72A1B4A701A5"),
                UnitName = "ADET",
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
            modelBuilder.Entity<Unit>().HasData(new Unit
            {
                Id = Guid.Parse("80B9D90C-C1BB-41B5-9FF3-2E0CA28D64FA"),
                UnitName = "KG",
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
            modelBuilder.Entity<Unit>().HasData(new Unit
            {
                Id = Guid.Parse("B08F5C83-252F-4629-9EC0-65EADFE4C0F1"),
                UnitName = "Paket",
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
            modelBuilder.Entity<Kdv>().HasData(new Kdv
            {
                Id = Guid.Parse("A9FD0162-8F72-4D24-ACCC-1B0C1EC494B4"),
                KdvName = "%18",
                KdvRatio =18,
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
            modelBuilder.Entity<Kdv>().HasData(new Kdv
            {
                Id = Guid.Parse("0924A136-4B38-42EB-AD09-7B92F1303B8A"),
                KdvName = "%20",
                KdvRatio = 20,
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
            modelBuilder.Entity<Kdv>().HasData(new Kdv
            {
                Id = Guid.Parse("71CC7301-CAE0-4937-A1B3-B7697291A176"),
                KdvName = "%0",
                KdvRatio = 0,
                CreateDate = DateTime.UtcNow,
                CreatedUser = "Admin"
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BankMotion ilişkiler
            modelBuilder.Entity<BankMotion>().HasOne(e => e.Bank).WithMany(e => e.BankMotions).HasForeignKey(e => e.BankId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankMotion>().HasOne(e => e.Customer).WithMany(e => e.BankMotions).HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.NoAction);

            //Customer İlişkiler
            modelBuilder.Entity<Customer>().HasOne(e => e.CustomerGroup).WithMany(e => e.Customers).HasForeignKey(e => e.CustomerGroupId).OnDelete(DeleteBehavior.NoAction);

            //CustomerUnderGroup İlişkileri
            modelBuilder.Entity<CustomerUnderGroup>().HasOne(c => c.CustomerGroup).WithMany(c => c.CustomerUnderGroups).HasForeignKey(c => c.CustomerGroupId).OnDelete(DeleteBehavior.NoAction);

            //Discount İlişkiler
            modelBuilder.Entity<Discount>().HasOne(e => e.Product).WithMany(e => e.Discounts).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);

            //EmployeeMotion İlişkiler
            modelBuilder.Entity<EmployeeMotion>().HasOne(e => e.Employee).WithMany(e => e.EmployeeMotions).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);

            //FastSale İlişkiler
            modelBuilder.Entity<FastSale>().HasOne(e => e.FastSaleGroup).WithMany(e => e.FastSales).HasForeignKey(e => e.FastSaleGroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FastSale>().HasOne(e => e.Product).WithMany(e => e.FastSales).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction);

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
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
