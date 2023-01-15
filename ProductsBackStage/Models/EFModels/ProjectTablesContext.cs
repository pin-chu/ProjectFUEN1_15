﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductsBackStage.EFModels
{
    public partial class ProjectTablesContext : DbContext
    {
        public ProjectTablesContext()
        {
        }

        public ProjectTablesContext(DbContextOptions<ProjectTablesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<ProductPhotos> ProductPhotos { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ShoppingCarts> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Discount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasMany(d => d.Product)
                    .WithMany(p => p.Event)
                    .UsingEntity<Dictionary<string, object>>(
                        "EventItems",
                        l => l.HasOne<Products>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK__EventItem__Produ__3552E9B6"),
                        r => r.HasOne<Events>().WithMany().HasForeignKey("EventId").HasConstraintName("FK__EventItem__Event__345EC57D"),
                        j =>
                        {
                            j.HasKey("EventId", "ProductId").HasName("PK__EventIte__B204047C6C8B8B2B");

                            j.ToTable("EventItems");
                        });
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasIndex(e => e.EmailAccount, "UQ__Members__005407CDD62C4870")
                    .IsUnique();

                entity.Property(e => e.About).HasMaxLength(500);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthOfDate).HasColumnType("date");

                entity.Property(e => e.ConfirmCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.PhotoSticker)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RealName).HasMaxLength(50);

                entity.HasMany(d => d.Product)
                    .WithMany(p => p.Member)
                    .UsingEntity<Dictionary<string, object>>(
                        "Favorites",
                        l => l.HasOne<Products>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK__Favorites__Produ__29E1370A"),
                        r => r.HasOne<Members>().WithMany().HasForeignKey("MemberId").HasConstraintName("FK__Favorites__Membe__28ED12D1"),
                        j =>
                        {
                            j.HasKey("MemberId", "ProductId").HasName("PK__Favorite__C7B087743595DF50");

                            j.ToTable("Favorites");
                        });
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__OrderDeta__Membe__5DCAEF64");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderIte__08D097A3182251D2");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__308E3499");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__318258D2");
            });

            modelBuilder.Entity<ProductPhotos>(entity =>
            {
                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductPh__Produ__2610A626");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.ManufactorDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductSpec)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__BrandI__2334397B");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__22401542");
            });

            modelBuilder.Entity<ShoppingCarts>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ProductId })
                    .HasName("PK__Shopping__C7B08774F4116008");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__ShoppingC__Membe__2CBDA3B5");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShoppingC__Produ__2DB1C7EE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}