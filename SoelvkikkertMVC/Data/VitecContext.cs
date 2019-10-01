using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoelvkikkertMVC.Models;

namespace SoelvkikkertMVC.Models
{
    public class VitecContext : DbContext
    {
        public VitecContext (DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<SoelvkikkertMVC.Models.Product> Product { get; set; }

        public DbSet<SoelvkikkertMVC.Models.Subscriber> Subscriber { get; set; }
    }
}
