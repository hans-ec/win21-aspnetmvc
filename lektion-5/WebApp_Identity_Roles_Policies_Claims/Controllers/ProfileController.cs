using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Identity_Roles_Policies_Claims.Data;
using WebApp_Identity_Roles_Policies_Claims.Models;
using WebApp_Identity_Roles_Policies_Claims.Models.ViewModels;

namespace WebApp_Identity_Roles_Policies_Claims.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ProfileViewModel();
            
            viewModel.Address = await _context.UserAddresses.Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == User.FindFirst("UserId").Value);

            return View(viewModel);
        }


        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UserProfileForm form)
        {
            return View();
        }

    }
}
