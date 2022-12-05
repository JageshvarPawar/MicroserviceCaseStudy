using Microsoft.AspNetCore.Mvc;
using Book.DBContext;

namespace Book.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private BookContext _context;

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
            _context = new BookContext();
        }

        [HttpGet]
        public IEnumerable <Book.Model.Book> Get()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{bookId}",Name ="GetAvailableCopies")]
        public int Get(string bookId)
        {
            return  _context.Books.Where(b => b.Id == bookId).Select(f => f.AvailableCopies).SingleOrDefault<int>();
       
        }

    }
}
