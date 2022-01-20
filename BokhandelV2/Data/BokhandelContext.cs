using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BokhandelV2.Models;

namespace BokhandelV2.Data
{
    public partial class BokhandelContext : DbContext
    {
        public BokhandelContext()
        {
        }

        public BokhandelContext(DbContextOptions<BokhandelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<StockBlance> StockBlances { get; set; } = null!;
        public virtual DbSet<VTitlarPerFörfattare> VTitlarPerFörfattares { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bokhandel;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn13)
                    .HasName("PK__Books__3BF79E03AE50F19D");

                entity.Property(e => e.Isbn13).IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__AuthorID__38996AB5");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__412EB0B6");

                entity.HasOne(d => d.OrderDetails)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderDetailsId)
                    .HasConstraintName("FK__Orders__OrderDet__403A8C7D");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.BooksIsbn13).IsFixedLength();

                entity.HasOne(d => d.BooksIsbn13Navigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BooksIsbn13)
                    .HasConstraintName("FK__OrderDeta__Books__3D5E1FD2");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Shops__CountryID__45F365D3");
            });

            modelBuilder.Entity<StockBlance>(entity =>
            {
                entity.HasKey(e => new { e.ShopsId, e.BooksIsbn13 })
                    .HasName("PK_komposit");

                entity.Property(e => e.BooksIsbn13).IsFixedLength();

                entity.HasOne(d => d.BooksIsbn13Navigation)
                    .WithMany(p => p.StockBlances)
                    .HasForeignKey(d => d.BooksIsbn13)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock Bla__Books__49C3F6B7");

                entity.HasOne(d => d.Shops)
                    .WithMany(p => p.StockBlances)
                    .HasForeignKey(d => d.ShopsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock Bla__Shops__48CFD27E");
            });

            modelBuilder.Entity<VTitlarPerFörfattare>(entity =>
            {
                entity.ToView("v_TitlarPerFörfattare");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
