using Microsoft.AspNetCore.Mvc;

namespace Review.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("init")]
        public IActionResult Init()
        {
            return Ok("hi");
        }
    }
}
