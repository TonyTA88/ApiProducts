using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Models
{   
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductLog> ProductLog { get; set; }
        public DbSet<SaelsT> SaelsT { get; set; }
        
    }
}
