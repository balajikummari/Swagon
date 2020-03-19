using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace JavaScriptClient.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Signin")]
        public IActionResult Signin()
        {
            return View();
        }
    }
}