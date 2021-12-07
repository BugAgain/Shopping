using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomDetail> CustomDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
