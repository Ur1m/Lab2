using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.Models;

namespace UserCourseInteraction.Database
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ShoppingCart> shopingCart { get; set; }
        public DbSet<WishList> wishLists { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductDto> productDtos { get; set; }
        public DbSet<Order> orders {get;set;}
        public DbSet<OrderItem> oredrItem { get; set; }
    }
}

