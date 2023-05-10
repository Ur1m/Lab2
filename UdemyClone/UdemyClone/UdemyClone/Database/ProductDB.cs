using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Models;
using Attribute = UdemyClone.Models.Attribute;

namespace UdemyClone.Database
{
    public class ProductDB:DbContext
    {
            public ProductDB(DbContextOptions<ProductDB> options) : base(options)
            {
            }
            
            public DbSet<Category> categories { get; set; }
            public DbSet<Product> products { get; set; }
            public DbSet<Review> reviews { get; set; }
            public DbSet<Attribute> atribues { get; set; }
            public DbSet<AttributeValue> atrvalues { get; set; }
            public DbSet<ProductAttribute> productattributes { get; set; }
        }
    }

