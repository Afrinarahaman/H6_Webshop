using Castle.Core.Resource;
using H5_Webshop.Database.Entities;
using H5_Webshop.DTOs.Entities;
using H5_Webshop.Helpers;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Database
{
    public class WebshopApiContext:DbContext
    {
     

        public WebshopApiContext() { }
        public WebshopApiContext(DbContextOptions<WebshopApiContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            modelBuilder.Entity<Category>().HasData(
               new()
               {
                   CategoryId = 1,
                   CategoryName = "Kids"


               },
               new()
               {
                   CategoryId = 2,
                   CategoryName = "Men"
               }
               );
            modelBuilder.Entity<Product>().HasData(
                new()
                {
                    ProductId = 1,
                    Title = " Fency dress",
                    Price = 299.99M,
                    Description = "kids dress",
                    Image = "dress1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },

                new()
                {
                    ProductId = 2,
                    Title = "Blue T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for nen",
                    Image = "BlueTShirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                },

                new()
                {
                    ProductId = 3,
                    Title = " Skirt",
                    Price = 159.99M,
                    Description = "Girls skirt",
                    Image = "skirt1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    ProductId = 4,
                    Title = " Jumpersuit",
                    Price = 279.99M,
                    Description = "kids jumpersuit",
                    Image = "jumpersuit1.jpg",
                    Stock = 10,
                    CategoryId = 1

                },
                new()
                {
                    ProductId = 5,
                    Title = "Red T-Shirt",
                    Price = 199.99M,
                    Description = "T-Shirt for men",
                    Image = "RedT-Shirt.jpg",
                    Stock = 10,
                    CategoryId = 2

                }
              );

            modelBuilder.Entity<User>().HasData(
               new()
               {
                   UserId = 1,
                   FirstName = "Peter",
              
                   LastName = "Aksten",
                   Email = "peter@abc.com",
                   Address="husum",
                   Telephone="+4512345678",
                   Password = "password",
                   Role = Role.Administrator
               },
               new()
               {
                   UserId = 2,
                   FirstName = "Rizwanah",
                  
                   LastName = "Mustafa",
                   Address = "husum",
                   Telephone = "+4512345678",
                   Email = "riz@abc.com",
                   Password = "password",
                   Role = Role.Member
               },
            new()
            {
                UserId = 3,
                FirstName = "Afrina",

                LastName = "Rahaman",
                Address = "husum",
                Telephone = "+4512345678",
                Email = "afr@abc.com",
                Password = "No Need",
                Role = Role.Guest
            }
            );





        }
    }
}
