using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Northwind.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasMany(e => e.ReportingEmployees)
                .WithOptional(e => e.ReportsToEmployee)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Territories)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeeTerritories").MapLeftKey("EmployeeID").MapRightKey("TerritoryID"));

            modelBuilder.Entity<OrderDetail>().Property(e => e.UnitPrice).HasPrecision(19, 4);

            modelBuilder.Entity<Order>().Property(e => e.CustomerCode).IsFixedLength();

            modelBuilder.Entity<Order>().Property(e => e.Freight).HasPrecision(19, 4);

            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails).WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>().Property(e => e.UnitPrice).HasPrecision(19, 4);

            modelBuilder.Entity<Product>().HasMany(e => e.OrderDetails).WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>().Property(e => e.RegionDescription).IsFixedLength();

            modelBuilder.Entity<Region>().HasMany(e => e.Territories).WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>().HasMany(e => e.Orders).WithOptional(e => e.Shipper)
                .HasForeignKey(e => e.ShipVia);

            modelBuilder.Entity<Territory>().Property(e => e.TerritoryDescription).IsFixedLength();

            base.OnModelCreating(modelBuilder);
        }
    }
}