using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLogin.Data;
using MVCLogin.Models;

namespace MVCLogin.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly VitecContext _context;

        public SubscriberController(VitecContext context)
        {
            _context = context;
        }

        // GET: Subscribers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscriber.ToListAsync());
        }

        // GET: Subscribers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Subscribers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Active,RowVersion")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriber);
        }

        // GET: Subscribers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Active,RowVersion")] Subscriber subscriber)
        {
            if (id != subscriber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriberExists(subscriber.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subscriber);
        }

        // GET: Subscribers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.Subscriber.FindAsync(id);
            _context.Subscriber.Remove(subscriber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscriber.Any(e => e.ID == id);
        }
    }
}
