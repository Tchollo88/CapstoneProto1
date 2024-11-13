using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneProto1;
using CapstoneProto1.Data;

namespace CapstoneProto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorPiecesController : ControllerBase
    {
        private readonly CapstoneProto1Db _context;

        public ArmorPiecesController(CapstoneProto1Db context)
        {
            _context = context;
        }

        // GET: api/ArmorPieces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArmorPiece>>> GetArmorPiece()
        {
            return await _context.ArmorPiece.ToListAsync();
        }

        // GET: api/ArmorPieces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArmorPiece>> GetArmorPiece(int id)
        {
            var armorPiece = await _context.ArmorPiece.FindAsync(id);

            if (armorPiece == null)
            {
                return NotFound();
            }

            return armorPiece;
        }

        // PUT: api/ArmorPieces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmorPiece(int id, ArmorPiece armorPiece)
        {
            if (id != armorPiece.ArmorPieceId)
            {
                return BadRequest();
            }

            _context.Entry(armorPiece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmorPieceExists(id))
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

        // POST: api/ArmorPieces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArmorPiece>> PostArmorPiece(ArmorPiece armorPiece)
        {
            _context.ArmorPiece.Add(armorPiece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmorPiece", new { id = armorPiece.ArmorPieceId }, armorPiece);
        }

        // DELETE: api/ArmorPieces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmorPiece(int id)
        {
            var armorPiece = await _context.ArmorPiece.FindAsync(id);
            if (armorPiece == null)
            {
                return NotFound();
            }

            _context.ArmorPiece.Remove(armorPiece);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmorPieceExists(int id)
        {
            return _context.ArmorPiece.Any(e => e.ArmorPieceId == id);
        }
    }
}
