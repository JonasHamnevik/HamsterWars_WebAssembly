using Core;
using HamsterWars.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamsterWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamsterController : ControllerBase
    {
        private readonly HamsterWarsDbContext _context;

        public HamsterController(HamsterWarsDbContext context)
        {
            _context = context;
        }

        //GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Hamster>>> GetAll() =>
            await _context.Hamsters.ToListAsync();

        //GetById
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hamster>> GetById(int id)
        {
            try
            {
                var hamster = await _context.Hamsters.FirstOrDefaultAsync((h) => h.Id == id);

                if (!HamsterExists(id))
                {
                    return NotFound();
                }

                return Ok(hamster);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //GetRandom
        //[HttpGet ("GetRandom")]
        //public async Task<ActionResult<IEnumerable<Hamster>>> GetRandom()
        //{
        //    Random random = new Random();
            
        //    var hamsterList = _context.Hamsters.ToList();
        //    var hamster = random.Next(hamsterList.Count);

        //    if (!HamsterExists(hamster))
        //    {
        //        random.Next(hamster);
        //    }
        //    return Ok(hamster);
        //}

        //Create
        [HttpPost]
        public async Task<ActionResult<Hamster>> Post([FromBody] Hamster hamster)
        {
            _context.Hamsters.Add(hamster);
            await _context.SaveChangesAsync();

            return NoContent();
            //return RedirectToAction("Index");
        }

        //Update
        [HttpPut ("{id}")]
        public async Task<IActionResult> Update(int id, Hamster hamster)
        {
            if (id != hamster.Id)
            {
                return BadRequest();
            }

            _context.Entry(hamster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HamsterExists(id))
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

        //Delete
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hamster = await _context.Hamsters.FindAsync(id);

            if (!HamsterExists(id))
            {
                return NotFound();
            }

            _context.Hamsters.Remove(hamster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HamsterExists(int id)
        {
            return (_context.Hamsters?.Any(h => h.Id == id)).GetValueOrDefault();
        }

    }
}
