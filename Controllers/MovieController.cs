using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_movie.CapaDatos;
using prueba_movie.CapaEntidad;

namespace prueba_movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly AppDbContext _context;

        public MovieController(ILogger<MovieController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> listMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovies(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetMovies", new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovies(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovies(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
    }
}