﻿// <auto-generated />
using System;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Entity.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Entity.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Author")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("CommentCount");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("Cover")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Digest")
                        .HasMaxLength(500);

                    b.Property<bool>("IsDraft");

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("IX_Article_Title");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Blog.Entity.ArticleCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Article");

                    b.Property<int>("Category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("Article", "Category");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("Blog.Entity.ArticleTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Article");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<int>("Tag");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Tag");

                    b.HasIndex("Article", "Tag");

                    b.ToTable("ArticleTags");
                });

            modelBuilder.Entity("Blog.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Category");

                    b.HasIndex("Name", "Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Blog.Entity.OperationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasMaxLength(200);

                    b.Property<string>("Area")
                        .HasMaxLength(200);

                    b.Property<string>("Controller")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LoginName")
                        .HasMaxLength(200);

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("OperationLog");
                });

            modelBuilder.Entity("Blog.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Role_Name_uindex")
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 391, DateTimeKind.Local).AddTicks(1122),
                            IsDeleted = false,
                            IsEnabled = true,
                            Name = "Admin",
                            UpdatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 391, DateTimeKind.Local).AddTicks(1136)
                        });
                });

            modelBuilder.Entity("Blog.Entity.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Blog.Entity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 391, DateTimeKind.Local).AddTicks(2707),
                            IsDeleted = false,
                            RoleId = 1,
                            UpdatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 391, DateTimeKind.Local).AddTicks(2710),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Blog.Entity.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AuthUpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("RealName")
                        .HasMaxLength(60);

                    b.Property<string>("Remark")
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthUpdatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 389, DateTimeKind.Local).AddTicks(1693),
                            CreatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 389, DateTimeKind.Local).AddTicks(302),
                            IsDeleted = false,
                            LoginName = "admin",
                            Password = "$SGHASH$V1$10000$RA3Eaw5yszeel1ARIe7iFp2AGWWLd80dAMwr+V4mRcAimv8u",
                            RealName = "Admin",
                            Status = 1,
                            UpdatedAt = new DateTime(2019, 5, 9, 20, 22, 47, 389, DateTimeKind.Local).AddTicks(1202)
                        });
                });

            modelBuilder.Entity("Blog.Entity.Article", b =>
                {
                    b.HasOne("Blog.Entity.Users", "AuthorNavigation")
                        .WithMany("Article")
                        .HasForeignKey("Author")
                        .HasConstraintName("FK_Article_Users")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Blog.Entity.ArticleCategories", b =>
                {
                    b.HasOne("Blog.Entity.Article", "ArticleNavigation")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("Article")
                        .HasConstraintName("FK_ArticleCategories_Article")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Blog.Entity.Category", "CategoryNavigation")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("Category")
                        .HasConstraintName("FK_ArticleCategories_Category")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Blog.Entity.ArticleTags", b =>
                {
                    b.HasOne("Blog.Entity.Article", "ArticleNavigation")
                        .WithMany("ArticleTags")
                        .HasForeignKey("Article")
                        .HasConstraintName("FK_ArticleTags_Article")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Blog.Entity.Tag", "TagNavigation")
                        .WithMany("ArticleTags")
                        .HasForeignKey("Tag")
                        .HasConstraintName("FK_ArticleTags_Tag")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Blog.Entity.UserRole", b =>
                {
                    b.HasOne("Blog.Entity.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.UserRole_dbo.Role_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Entity.Users", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.UserRole_dbo.sysUserInfo_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
