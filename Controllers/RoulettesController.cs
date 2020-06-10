using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouletteApi.Models;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoulettesController : ControllerBase
    {
        private readonly RouletteContext _context;

        public RoulettesController(RouletteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Roulette>> PostRoulette()
        {
            var roulette = new Roulette();
            _context.Roulettes.Add(roulette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoulette", new { id = roulette.Id }, new { rouletteId = roulette.Id });
        }

        [HttpPost("{id}/open")]
        public async Task<ActionResult<Roulette>> OpenRoulette(long id)
        {
            var roulette = await _context.Roulettes.FindAsync(id);
            if (roulette == null)
            {
                return NotFound();
            }
            else
            {
                roulette.Open();
                return Ok(new { Status = "Ok"});
            } 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roulette>>> GetRoulletes()
        {
            
            return await _context.Roulettes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roulette>> GetRoulette(long id)
        {
            var roulette = await _context.Roulettes.FindAsync(id);

            if (roulette == null)
            {
                return NotFound();
            }

            return roulette;
        }
    }
}
