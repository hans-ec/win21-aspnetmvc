using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
