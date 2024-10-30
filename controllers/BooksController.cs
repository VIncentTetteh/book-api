
using BooksAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase{
        private readonly AppDbContext _context;
        
        public BooksController(AppDbContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Book>>> GetBooks(){
            return await _context.Books.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Models.Book>> CreateBook(Models.Book book){
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new {id = book.Id}, book);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Book>> GetBook(int id){
            var book = await _context.Books.FindAsync(id);
            if(book == null){
                return NotFound();
            }
            return book;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Models.Book book){
            if(id != book.Id){
                return BadRequest();
            }
            _context.Entry(book).State = EntityState.Modified;
           
            await _context.SaveChangesAsync();
            
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id){
            var book = await _context.Books.FindAsync(id);
            if(book == null){
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

}