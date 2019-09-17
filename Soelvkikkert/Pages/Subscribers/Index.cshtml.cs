using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soelvkikkert.Models;

namespace Soelvkikkert.Pages_Subscribers
{
    public class IndexModel : PageModel
    {
        private readonly Soelvkikkert.Models.VitecContext _context;

        public IndexModel(Soelvkikkert.Models.VitecContext context)
        {
            _context = context;
        }

        public IList<Subscriber> Subscriber { get;set; }

        public async Task OnGetAsync()
        {
            Subscriber = await _context.Subscriber.ToListAsync();
        }
    }
}
