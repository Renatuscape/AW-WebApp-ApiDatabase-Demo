using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDb_Demo.Data;
using WebAppDb_Demo.Models;
using Microsoft.AspNetCore.Http;

namespace WebAppDb_Demo.Controllers
{
    [ApiController]
    [Route("albums")]
    public class AlbumController : ControllerBase //inheriting from ControllerBase gives access to codes
    {
        private readonly AlbumDbContext _context;
        public AlbumController(AlbumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Album.ToListAsync());
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            //ApiController will automatically check if ModelState is valid

            _context.Album.Add(album);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = album.Id}, album);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            //var doesAlbumExist = await _context.Album.FindAsync(album.Id);
            ////Does not work well with Entry().State
            //if (doesAlbumExist == null)
            //{
            //    return NotFound();
            //}

            //Change object state to the entry that matches by ID
            _context.Entry(album).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(album);
        }

        [HttpDelete("{id}")] //ID is required here if an object isn't sent in
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if (album == null )
            {
                return NotFound();
            }
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
