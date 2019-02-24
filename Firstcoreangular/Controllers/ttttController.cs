using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firstcoreangular.Model;

namespace Firstcoreangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ttttController : ControllerBase
    {
        private readonly PaymentDetailsContext _context;

        public ttttController(PaymentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/tttt
        [HttpGet]
        public IEnumerable<PaymentDetails> GetPaymentDetails()
        {
            return _context.PaymentDetails;
        }

        // GET: api/tttt/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentDetails = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return Ok(paymentDetails);
        }

        // PUT: api/tttt/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetails([FromRoute] int id, [FromBody] PaymentDetails paymentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentDetails.PMId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
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

        // POST: api/tttt
        [HttpPost]
        public async Task<IActionResult> PostPaymentDetails([FromBody] PaymentDetails paymentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentDetails.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PMId }, paymentDetails);
        }

        // DELETE: api/tttt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentDetails = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return Ok(paymentDetails);
        }

        private bool PaymentDetailsExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PMId == id);
        }
    }
}