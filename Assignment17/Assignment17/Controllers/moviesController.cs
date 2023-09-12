using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment17.Data;
using Assignment17.Models;

namespace Assignment17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public moviesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<movies>>> Getmovies()
        {
          if (_context.movies == null)
          {
              return NotFound();
          }
            return await _context.movies.ToListAsync();
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<movies>> Getmovies(int id)
        {
          if (_context.movies == null)
          {
              return NotFound();
          }
            var movies = await _context.movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
        }

        // PUT: api/movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmovies(int id, movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!moviesExists(id))
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

        // POST: api/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<movies>> Postmovies(movies movies)
        {
          if (_context.movies == null)
          {
              return Problem("Entity set 'MoviesDbContext.movies'  is null.");
          }
            _context.movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmovies", new { id = movies.Id }, movies);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemovies(int id)
        {
            if (_context.movies == null)
            {
                return NotFound();
            }
            var movies = await _context.movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool moviesExists(int id)
        {
            return (_context.movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
