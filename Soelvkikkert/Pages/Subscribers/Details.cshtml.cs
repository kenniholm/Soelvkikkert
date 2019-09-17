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
    public class DetailsModel : PageModel
    {
        private readonly Soelvkikkert.Models.VitecContext _context;

        public DetailsModel(Soelvkikkert.Models.VitecContext context)
        {
            _context = context;
        }

        public Subscriber Subscriber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscriber = await _context.Subscriber.FirstOrDefaultAsync(m => m.ID == id);

            if (Subscriber == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
