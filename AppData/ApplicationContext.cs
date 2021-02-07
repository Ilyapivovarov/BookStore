using System;
using BookStore.AppData.Entities;
using BookStore.AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AppData
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
