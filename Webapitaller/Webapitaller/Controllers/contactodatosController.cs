using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapitaller.Models;

namespace Webapitaller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class contactodatosController : ControllerBase
    {
        private readonly contactodatoscontex _context;

        public contactodatosController(contactodatoscontex context)
        {
            _context = context;
        }

        // GET: api/contactodatos
        [HttpGet]
        public IEnumerable<contactodatos> Getcontactodatoss()
        {
            return _context.contactodatoss;
        }

        // GET: api/contactodatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getcontactodatos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactodatos = await _context.contactodatoss.FindAsync(id);

            if (contactodatos == null)
            {
                return NotFound();
            }

            return Ok(contactodatos);
        }

        // PUT: api/contactodatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcontactodatos([FromRoute] int id, [FromBody] contactodatos contactodatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactodatos.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactodatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactodatosExists(id))
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

        // POST: api/contactodatos
        [HttpPost]
        public async Task<IActionResult> Postcontactodatos([FromBody] contactodatos contactodatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.contactodatoss.Add(contactodatos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Getcontactodatos), new { id = contactodatos.Id }, contactodatos);
        }

        // DELETE: api/contactodatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecontactodatos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactodatos = await _context.contactodatoss.FindAsync(id);
            if (contactodatos == null)
            {
                return NotFound();
            }

            _context.contactodatoss.Remove(contactodatos);
            await _context.SaveChangesAsync();

            return Ok(contactodatos);
        }

        private bool contactodatosExists(int id)
        {
            return _context.contactodatoss.Any(e => e.Id == id);
        }
    }
}