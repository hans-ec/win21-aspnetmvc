using Microsoft.AspNetCore.Mvc;

namespace Repetition.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
