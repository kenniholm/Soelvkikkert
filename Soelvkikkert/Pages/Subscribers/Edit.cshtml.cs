using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soelvkikkert.Models;

namespace Soelvkikkert.Pages_Subscribers
{
    public class EditModel : PageModel
    {
        private readonly Soelvkikkert.Models.VitecContext _context;

        public EditModel(Soelvkikkert.Models.VitecContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(Subscriber.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscriber.Any(e => e.ID == id);
        }
    }
}
