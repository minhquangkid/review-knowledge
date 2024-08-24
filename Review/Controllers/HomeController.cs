using Microsoft.AspNetCore.Mvc;

namespace Review.Controllers
{
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("init")]
        public IActionResult Init()
        {
            return Ok(new { data = "this is back end" });
        }
    }
}
