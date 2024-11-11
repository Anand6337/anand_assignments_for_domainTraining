using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB_First_Demo.Models
{
    public partial class BikeStoresContext : DbContext
    {
        public BikeStoresContext()
        {
        }

        public BikeStoresContext(DbContextOptions<BikeStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeAudit> EmployeeAudits { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=VIVEK21\\SQLEXPRESS;Database=BikeStores;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Bookings__RoomID__44CA3770");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands", "production");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("brand_name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "production");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers", "sales");

                entity.HasIndex(e => new { e.FirstName, e.LastName }, "idx_name");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip_code");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("PK__Employee__A17F23B8601C46BA");

                entity.ToTable("Employee_Audit");

                entity.Property(e => e.AuditId).HasColumnName("AuditID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "sales");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("date")
                    .HasColumnName("required_date");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shipped_date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__orders__customer__59FA5E80");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__staff_id__5BE2A6F2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__orders__store_id__5AEE82B9");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PK__order_it__837942D437C497DA");

                entity.ToTable("order_items", "sales");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("list_price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_ite__order__5FB337D6");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_ite__produ__60A75C0F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", "production");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("list_price");

                entity.Property(e => e.ModelYear).HasColumnName("model_year");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__products__brand___4E88ABD4");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__products__catego__4D94879B");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staffs", "sales");

                entity.HasIndex(e => e.Email, "UQ__staffs__AB6E6164209986CE")
                    .IsUnique();

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__staffs__manager___571DF1D5");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__staffs__store_id__5629CD9C");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__stocks__E68284D340D5BC8C");

                entity.ToTable("stocks", "production");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__stocks__product___6477ECF3");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__stocks__store_id__6383C8BA");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores", "sales");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("store_name");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip_code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
