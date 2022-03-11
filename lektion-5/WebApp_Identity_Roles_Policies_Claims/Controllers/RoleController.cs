using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Identity_Roles_Policies_Claims.Controllers
{
    [Authorize(Policy = "Admins")]
    //[Authorize(Roles = "admin,user")]
    public class RoleController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }

    }
}
