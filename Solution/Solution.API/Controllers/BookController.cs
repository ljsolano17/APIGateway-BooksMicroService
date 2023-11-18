using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Solution.DAL.Repository;
using Solution.DO.Objects;
using System.Security.Cryptography;


namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMongoRepository<Book> _bookRepository;
        public BookController(IMongoRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }


        // GET: api/<BookController>
        [Route("GetBooks")]
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return new BS.Book(_bookRepository).GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(string oid)
        {
            var book = new BS.Book(_bookRepository).GetOneById(oid);
            if (book == null)
            {
                return BadRequest();
            }
            return book;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook( Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            new BS.Book(_bookRepository).Insert(book);
            return CreatedAtAction("GetBooks", new { id = book.Id }, book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{oid}")]
        public async Task<IActionResult> PutBook(string oid, Book book)
        {
            if (string.IsNullOrEmpty(oid))
            {
                return BadRequest();
            }

            try
            {
                book.Id = oid; 
                new BS.Book(_bookRepository).Update(book);
            }
            catch (Exception ee)
            {
                if (BookExists(oid))
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

        // DELETE api/<BookController>/5
        [HttpDelete("{oid}")]
        public async Task<ActionResult<Book>> Delete(string oid)
        {
            var book = new BS.Book(_bookRepository).GetOneById(oid);
            if (book == null)
            {
                return NotFound();
            }
            new BS.Book(_bookRepository).Delete(book);
            return book;

        }

        private bool BookExists(string oid)
        {
            return (new BS.Book(_bookRepository).GetOneById(oid) != null);
        }
    }
}
