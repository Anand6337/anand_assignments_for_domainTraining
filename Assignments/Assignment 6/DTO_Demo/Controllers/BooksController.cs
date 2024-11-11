using AutoMapper;
using DTO_Demo.DTO;
using DTO_Demo.Mappings;
using DTO_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTO_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks()
        {
            List<Book> books = _context.Books.ToList();
            if (books != null)
            {
                //  List<BookDTO> bookDTOs = books.ToDTOList();
                List<BookDTO> bookDtos = _mapper.Map<List<BookDTO>>(books);
                return bookDtos;
            }
            else
            { return NotFound(); }
        }
        [HttpPost]
        public ActionResult PostBook(BookDTO bookDTO)
        {
            //  var book=bookDTO.ToEntity();
            var book = _mapper.Map<Book>(bookDTO);
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PostBook), new { id = book.Id }, bookDTO);
        }
    }
}
