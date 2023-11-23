using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerOrderServices.Models
{
    public partial class CustomerOrderServicesContext : DbContext
    {
        public CustomerOrderServicesContext()
        {
        }

        public CustomerOrderServicesContext(DbContextOptions<CustomerOrderServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DJHE6F4\\SQLEXPRESS;Database=CustomerOrderServices;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Phonenumber, "UQ__customer__622BF0C2C01487E5")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .HasColumnName("customer_id");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(12)
                    .HasColumnName("phonenumber");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__customer__46596229D850D82C");

                entity.ToTable("customer_orders");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .HasColumnName("order_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .HasColumnName("customer_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("date_created");

                entity.Property(e => e.DetailOrder)
                    .HasMaxLength(50)
                    .HasColumnName("detail_order");

                entity.Property(e => e.StateOrder)
                    .HasMaxLength(20)
                    .HasColumnName("state_order");

                entity.Property(e => e.TotalOrder)
                    .HasColumnType("money")
                    .HasColumnName("total_order");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__customer___custo__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
