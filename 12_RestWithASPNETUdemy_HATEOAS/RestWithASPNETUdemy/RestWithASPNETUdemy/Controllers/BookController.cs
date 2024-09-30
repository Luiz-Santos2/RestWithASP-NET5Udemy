using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace RestWithASPNETUdemy.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class BookController : ControllerBase
    {    

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
            { 
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }
        [HttpPut]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
             return NoContent();
        }
    }
}
