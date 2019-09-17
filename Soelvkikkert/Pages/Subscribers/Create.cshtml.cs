using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Soelvkikkert.Models;

namespace Soelvkikkert.Pages_Subscribers
{
    public class CreateModel : PageModel
    {
        private readonly Soelvkikkert.Models.VitecContext _context;

        public CreateModel(Soelvkikkert.Models.VitecContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subscriber Subscriber { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscriber.Add(Subscriber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}