using Microsoft.AspNetCore.Mvc;

namespace Repetition.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
