using Microsoft.AspNetCore.Mvc;

namespace Repetition.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
