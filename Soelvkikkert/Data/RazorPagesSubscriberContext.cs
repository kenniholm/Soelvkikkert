using Microsoft.EntityFrameworkCore;

namespace Soelvkikkert.Models
{
    public class RazorPagesSubscriberContext : DbContext
    {
        public RazorPagesSubscriberContext(DbContextOptions<RazorPagesSubscriberContext> options)
            : base(options)
        {
        }

        public DbSet<Soelvkikkert.Models.Subscriber> Movie { get; set; }
    }
}