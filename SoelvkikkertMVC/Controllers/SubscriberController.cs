using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoelvkikkertMVC.Models;

namespace SoelvkikkertMVC.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly VitecContext _context;

        public SubscriberController(VitecContext context)
        {
            _context = context;
        }

        // GET: Subscriber
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscriber.ToListAsync());
        }

        // GET: Subscriber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscriber
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Subscriber/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscriber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,PhoneNumber,FirstName,LastName,Active")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriber);
        }

        // GET: Subscriber/Edit/5
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

        // POST: Subscriber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriberToUpdate = await _context.Subscriber/*.Include(i => i.Administrator)*/.FirstOrDefaultAsync(m => m.ID == id);

            if (subscriberToUpdate == null)
            {
                Subscriber deletedSubscriber = new Subscriber();
                await TryUpdateModelAsync(deletedSubscriber);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The subscriber was deleted by another user.");
                ViewData["ID"] = new SelectList(_context.Subscriber, "ID", "FirstName", deletedSubscriber.ID);
                return View(deletedSubscriber);
            }

            _context.Entry(subscriberToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Subscriber>(
                subscriberToUpdate,
                "",
                s => s.FirstName, s => s.LastName, s => s.PhoneNumber, s => s.ID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Subscriber)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The subscriber was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Subscriber)databaseEntry.ToObject();

                        if (databaseValues.FirstName != clientValues.FirstName)
                        {
                            ModelState.AddModelError("FirstName", $"Current value: {databaseValues.FirstName}");
                        }
                        if (databaseValues.LastName != clientValues.LastName)
                        {
                            ModelState.AddModelError("LastName", $"Current value: {databaseValues.LastName:c}");
                        }
                        if (databaseValues.PhoneNumber != clientValues.PhoneNumber)
                        {
                            ModelState.AddModelError("PhoneNumber", $"Current value: {databaseValues.PhoneNumber:d}");
                        }

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        subscriberToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["ID"] = new SelectList(_context.Subscriber, "ID", "FirstName", subscriberToUpdate.ID);
            return View(subscriberToUpdate);
        }

        // GET: Subscriber/Delete/5
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

        // POST: Subscriber/Delete/5
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
