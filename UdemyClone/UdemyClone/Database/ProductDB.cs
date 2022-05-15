using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyClone.Models;

namespace UdemyClone.Database
{
    public class ProductDB:DbContext
    {
        
            public ProductDB(DbContextOptions<ProductDB> options) : base(options)
            {

            }
            public DbSet<Category> categories { get; set; }
         
        }
    }

