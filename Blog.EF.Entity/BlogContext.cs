﻿using Blog.API.Common.Constants;
using Blog.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Blog.EF.Entity
{
    public partial class BlogContext : DbContext
    {
        public BlogContext() { }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategories> ArticleCategories { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OperationLog> OperationLog { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.Development.json", optional: false).Build();

                // for db migration
                optionsBuilder.UseSqlServer(config[$"{nameof(DbConfiguration)}:{nameof(DbConfiguration.ConnectionString)}"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            // set default value of parent entity
            foreach (var entityType in builder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType).Property("CreatedAt")
                    .HasDefaultValueSql("getdate()");
                builder.Entity(entityType.ClrType).Property("UpdatedAt")
                    .HasDefaultValueSql("getdate()");
            }

            builder.Entity<Article>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Article_Title")
                    .IsUnique();

                entity.Property(e => e.Author).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_Article_Users");
            });

            builder.Entity<ArticleCategories>(entity =>
            {
                entity.HasIndex(e => new { e.Article, e.Category });

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.ArticleCategories)
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleCategories_Article");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ArticleCategories)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleCategories_Category");
            });

            builder.Entity<ArticleTags>(entity =>
            {
                entity.HasIndex(e => new { e.Article, e.Tag });

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleTags_Article");

                entity.HasOne(d => d.TagNavigation)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.Tag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleTags_Tag");
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Category")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Id });
            });

            builder.Entity<OperationLog>(entity =>
            {
                entity.Property(e => e.IPAddress).IsUnicode(false);
            });

            builder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("Role_Name_uindex")
                    .IsUnique();
            });

            builder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Id });
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.UserRole_dbo.Role_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserRole_dbo.sysUserInfo_UserId");
            });

            builder.Entity<Users>(entity =>
            {
                entity.Property(e => e.AuthUpdatedAt).HasDefaultValueSql("(getdate())");
            });

            // insert admin
            builder.Entity<Users>().HasData(new Users
            {
                Id = 1,
                LoginName = "admin",
                // 123456
                Password = "$SGHASH$V1$10000$RA3Eaw5yszeel1ARIe7iFp2AGWWLd80dAMwr+V4mRcAimv8u",
                RealName = "Admin",
                Status = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthUpdatedAt = DateTime.Now,
                Remark = null,
                IsDeleted = false
            });

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}