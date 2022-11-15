using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HollywoodService.Data;
using HollywoodService.Models;

namespace HollywoodService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly HollywoodServiceContext _context;

        public ImagesController(HollywoodServiceContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieImage>>> GetMovieImages()
        {
            return await _context.MovieImages.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieImage>> GetMovieImage(int id)
        {
            var movieImage = await _context.MovieImages.FindAsync(id);

            if (movieImage == null)
            {
                return NotFound();
            }

            return movieImage;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieImage(int id, MovieImage movieImage)
        {
            if (id != movieImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieImageExists(id))
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

        // POST: api/Images
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieImage>> PostMovieImage(MovieImage movieImage)
        {
            _context.MovieImages.Add(movieImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieImage", new { id = movieImage.Id }, movieImage);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieImage>> DeleteMovieImage(int id)
        {
            var movieImage = await _context.MovieImages.FindAsync(id);
            if (movieImage == null)
            {
                return NotFound();
            }

            _context.MovieImages.Remove(movieImage);
            await _context.SaveChangesAsync();

            return movieImage;
        }

        private bool MovieImageExists(int id)
        {
            return _context.MovieImages.Any(e => e.Id == id);
        }
    }
}
