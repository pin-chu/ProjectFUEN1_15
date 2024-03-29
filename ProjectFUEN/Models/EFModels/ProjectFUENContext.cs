﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectFUEN.Models.VM;

namespace ProjectFUEN.Models.EFModels
{
    public partial class ProjectFUENContext : DbContext
    {
        public ProjectFUENContext()
        {
        }

        public ProjectFUENContext(DbContextOptions<ProjectFUENContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }
        public virtual DbSet<ActivityCollection> ActivityCollections { get; set; }
        public virtual DbSet<ActivityMember> ActivityMembers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumItem> AlbumItems { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentReport> CommentReports { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<FollowInfo> FollowInfos { get; set; }
        public virtual DbSet<IndiscriminateReport> IndiscriminateReports { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OthersCollection> OthersCollections { get; set; }
        public virtual DbSet<OwnCollection> OwnCollections { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PhotoReport> PhotoReports { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<View> Views { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CoverImage)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateOfCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.GatheringTime).HasColumnType("datetime");

                entity.Property(e => e.Recommendation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Activitie__Categ__34C8D9D1");

                entity.HasOne(d => d.Istructor)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.IstructorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Activitie__Istru__33D4B598");
            });

            modelBuilder.Entity<ActivityCategory>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder, "UQ__Activity__FB8517E6D7F2F089")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ActivityCollection>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityCollections)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__ActivityC__Activ__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityCollections)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ActivityC__UserI__398D8EEE");
            });

            modelBuilder.Entity<ActivityMember>(entity =>
            {
                entity.Property(e => e.DateJoined)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityMembers)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__ActivityM__Activ__3D5E1FD2");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ActivityMembers)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__ActivityM__Membe__3E52440B");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Albums__MemberId__46B27FE2");
            });

            modelBuilder.Entity<AlbumItem>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.PhotoId })
                    .HasName("PK__AlbumIte__A5AFC56986FD06B2");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumItems)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__AlbumItem__Album__4A8310C6");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.AlbumItems)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK__AlbumItem__Photo__4B7734FF");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answers__Questio__46E78A0C");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Comments__Member__6442E2C9");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Comments__PhotoI__65370702");
            });

            modelBuilder.Entity<CommentReport>(entity =>
            {
                entity.Property(e => e.ReportTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentReports)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__CommentRe__Comme__18B6AB08");

                entity.HasOne(d => d.ReporterNavigation)
                    .WithMany(p => p.CommentReports)
                    .HasForeignKey(d => d.Reporter)
                    .HasConstraintName("FK__CommentRe__Repor__17C286CF");
            });

            modelBuilder.Entity<Coupon>(entity =>
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

            modelBuilder.Entity<Event>(entity =>
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

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Events)
                    .UsingEntity<Dictionary<string, object>>(
                        "EventItem",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK__EventItem__Produ__3552E9B6"),
                        r => r.HasOne<Event>().WithMany().HasForeignKey("EventId").HasConstraintName("FK__EventItem__Event__345EC57D"),
                        j =>
                        {
                            j.HasKey("EventId", "ProductId").HasName("PK__EventIte__B204047C6C8B8B2B");

                            j.ToTable("EventItems");
                        });
            });

            modelBuilder.Entity<FollowInfo>(entity =>
            {
                entity.HasKey(e => new { e.Follower, e.Following })
                    .HasName("PK__FollowIn__512B98D2831ED227");

                entity.Property(e => e.FollowTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FollowerNavigation)
                    .WithMany(p => p.FollowInfoFollowerNavigations)
                    .HasForeignKey(d => d.Follower)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowInf__Follo__5F7E2DAC");

                entity.HasOne(d => d.FollowingNavigation)
                    .WithMany(p => p.FollowInfoFollowingNavigations)
                    .HasForeignKey(d => d.Following)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowInf__Follo__607251E5");
            });

            modelBuilder.Entity<IndiscriminateReport>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Indiscri__0CF04B18F9117A1A");

                entity.Property(e => e.MemberId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.InstructorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResumePhoto)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Member>(entity =>
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

                entity.HasMany(d => d.Coupons)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsedCoupon",
                        l => l.HasOne<Coupon>().WithMany().HasForeignKey("CouponId").HasConstraintName("FK__UsedCoupo__Coupo__6D0D32F4"),
                        r => r.HasOne<Member>().WithMany().HasForeignKey("MemberId").HasConstraintName("FK__UsedCoupo__Membe__6C190EBB"),
                        j =>
                        {
                            j.HasKey("MemberId", "CouponId").HasName("PK__UsedCoup__BF74E403CCFD7B38");

                            j.ToTable("UsedCoupons");
                        });

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "Favorite",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK__Favorites__Produ__29E1370A"),
                        r => r.HasOne<Member>().WithMany().HasForeignKey("MemberId").HasConstraintName("FK__Favorites__Membe__28ED12D1"),
                        j =>
                        {
                            j.HasKey("MemberId", "ProductId").HasName("PK__Favorite__C7B087743595DF50");

                            j.ToTable("Favorites");
                        });
            });

            modelBuilder.Entity<OrderDetail>(entity =>
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

            modelBuilder.Entity<OrderItem>(entity =>
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

            modelBuilder.Entity<OthersCollection>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.PhotoId })
                    .HasName("PK__OthersCo__3EEB304655899A08");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.OthersCollections)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__OthersCol__Membe__4F47C5E3");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.OthersCollections)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK__OthersCol__Photo__503BEA1C");
            });

            modelBuilder.Entity<OwnCollection>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.PhotoId })
                    .HasName("PK__OwnColle__3EEB3046FB42C839");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.OwnCollections)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__OwnCollec__Membe__540C7B00");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.OwnCollections)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK__OwnCollec__Photo__55009F39");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Aperture)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Camera)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Negative)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pixel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShootingTime).HasColumnType("datetime");

                entity.Property(e => e.Shutter)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UploadTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Photos__Author__42E1EEFE");
            });

            modelBuilder.Entity<PhotoReport>(entity =>
            {
                entity.Property(e => e.ReportTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PhotoReports)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK__PhotoRepo__Photo__09746778");

                entity.HasOne(d => d.ReporterNavigation)
                    .WithMany(p => p.PhotoReports)
                    .HasForeignKey(d => d.Reporter)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__PhotoRepo__Repor__0880433F");
            });

            modelBuilder.Entity<Product>(entity =>
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

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPhotos)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductPh__Produ__2610A626");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__Questions__Activ__4222D4EF");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Questions__Membe__4316F928");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
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

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(d => d.Photos)
                    .WithMany(p => p.Tags)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagItem",
                        l => l.HasOne<Photo>().WithMany().HasForeignKey("PhotoId").HasConstraintName("FK__TagItems__PhotoI__5BAD9CC8"),
                        r => r.HasOne<Tag>().WithMany().HasForeignKey("TagId").HasConstraintName("FK__TagItems__TagId__5AB9788F"),
                        j =>
                        {
                            j.HasKey("TagId", "PhotoId").HasName("PK__TagItems__576782F262B25D69");

                            j.ToTable("TagItems");
                        });
            });

            modelBuilder.Entity<View>(entity =>
            {
                entity.Property(e => e.ViewDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Views)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Views__MemberId__69FBBC1F");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Views)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK__Views__PhotoId__690797E6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        //public DbSet<ProjectFUEN.Models.VM.CategoryIndexVM> CategoryIndexVM { get; set; }

        //public DbSet<ProjectFUEN.Models.VM.ProductIndexVm> ProductIndexVm { get; set; }
    }
}