using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext (DbContextOptions<ProductAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductAPI.Models.Product> Product { get; set; }
    }
}
