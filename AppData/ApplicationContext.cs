using System;
using BookStore.AppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AppData
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
        }
    }
}
