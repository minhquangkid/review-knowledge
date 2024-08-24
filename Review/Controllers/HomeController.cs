using Microsoft.AspNetCore.Mvc;
using Review.Model;

namespace Review.Controllers
{
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("init")]
        public IActionResult Init()
        {
          var list = _context.Customers.ToList();
            return Ok(list);
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer payload)
        {
            _context.Customers.Add(payload);
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
