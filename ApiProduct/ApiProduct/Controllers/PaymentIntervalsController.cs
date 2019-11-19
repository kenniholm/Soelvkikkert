using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Models;

namespace ApiProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentIntervalsController : ControllerBase
    {
        private readonly ProductContext _context;

        public PaymentIntervalsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/PaymentIntervals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInterval>>> GetPaymentInterval()
        {
            return await _context.PaymentInterval.ToListAsync();
        }

        // GET: api/PaymentIntervals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentInterval>> GetPaymentInterval(int id)
        {
            var paymentInterval = await _context.PaymentInterval.FindAsync(id);

            if (paymentInterval == null)
            {
                return NotFound();
            }

            return paymentInterval;
        }

        // PUT: api/PaymentIntervals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentInterval(int id, PaymentInterval paymentInterval)
        {
            if (id != paymentInterval.ID)
            {
                return BadRequest();
            }

            _context.Entry(paymentInterval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentIntervalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentIntervals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PaymentInterval>> PostPaymentInterval(PaymentInterval paymentInterval)
        {
            _context.PaymentInterval.Add(paymentInterval);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentInterval", new { id = paymentInterval.ID }, paymentInterval);
        }

        // DELETE: api/PaymentIntervals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentInterval>> DeletePaymentInterval(int id)
        {
            var paymentInterval = await _context.PaymentInterval.FindAsync(id);
            if (paymentInterval == null)
            {
                return NotFound();
            }

            _context.PaymentInterval.Remove(paymentInterval);
            await _context.SaveChangesAsync();

            return paymentInterval;
        }

        private bool PaymentIntervalExists(int id)
        {
            return _context.PaymentInterval.Any(e => e.ID == id);
        }
    }
}
