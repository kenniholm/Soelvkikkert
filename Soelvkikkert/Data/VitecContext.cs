using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soelvkikkert.Models;

namespace Soelvkikkert.Models
{
    public class VitecContext : DbContext
    {
        public VitecContext (DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<Soelvkikkert.Models.Product> Product { get; set; }

        public DbSet<Soelvkikkert.Models.Subscriber> Subscriber { get; set; }
    }
}
