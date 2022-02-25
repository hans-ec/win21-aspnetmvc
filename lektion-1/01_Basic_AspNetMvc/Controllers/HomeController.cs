using _01_Basic_AspNetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01_Basic_AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // https://localhost:7263/
        // https://localhost:7263/Home/Index 
        public IActionResult Index()
        {
            return View();
        }


        // https://localhost:7263/Home/Privacy 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}