﻿// <auto-generated />
using System;
using H5_Webshop.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H5_Webshop.Migrations
{
    [DbContext(typeof(WebshopApiContext))]
    [Migration("20230703102352_Webshop_P6")]
    partial class Webshop_P6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("H5_Webshop.Database.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("Date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("H5_Webshop.Database.Entities.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("H5_Webshop.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "husum",
                            Email = "peter@abc.com",
                            FirstName = "Peter",
                            LastName = "Aksten",
                            Password = "password",
                            Role = 0,
                            Telephone = "+4512345678"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "husum",
                            Email = "riz@abc.com",
                            FirstName = "Rizwanah",
                            LastName = "Mustafa",
                            Password = "password",
                            Role = 1,
                            Telephone = "+4512345678"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "husum",
                            Email = "afr@abc.com",
                            FirstName = "Afrina",
                            LastName = "Rahaman",
                            Password = "No Need",
                            Role = 2,
                            Telephone = "+4512345678"
                        });
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Kids"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Men"
                        });
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "kids dress",
                            Image = "dress1.jpg",
                            Price = 299.99m,
                            Stock = (short)10,
                            Title = " Fency dress"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            Description = "T-Shirt for nen",
                            Image = "BlueTShirt.jpg",
                            Price = 199.99m,
                            Stock = (short)10,
                            Title = "Blue T-Shirt"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Girls skirt",
                            Image = "skirt1.jpg",
                            Price = 159.99m,
                            Stock = (short)10,
                            Title = " Skirt"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "kids jumpersuit",
                            Image = "jumpersuit1.jpg",
                            Price = 279.99m,
                            Stock = (short)10,
                            Title = " Jumpersuit"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Description = "T-Shirt for men",
                            Image = "RedT-Shirt.jpg",
                            Price = 199.99m,
                            Stock = (short)10,
                            Title = "Red T-Shirt"
                        });
                });

            modelBuilder.Entity("H5_Webshop.Database.Entities.Order", b =>
                {
                    b.HasOne("H5_Webshop.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("H5_Webshop.Database.Entities.OrderDetails", b =>
                {
                    b.HasOne("H5_Webshop.Database.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("H5_Webshop.DTOs.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Product", b =>
                {
                    b.HasOne("H5_Webshop.DTOs.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("H5_Webshop.Database.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("H5_Webshop.DTOs.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}