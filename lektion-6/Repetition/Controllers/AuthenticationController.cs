using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repetition.Models;
using Repetition.Models.Data;
using Repetition.Services;

namespace Repetition.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProfileManager _profileManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IProfileManager profileManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _profileManager = profileManager;
        }

        #region SignUp 

        [HttpGet]
        [Route("signup")]
        public IActionResult SignUp(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new SignUpForm();
            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            if (ModelState.IsValid)
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                if (!_userManager.Users.Any())
                    form.RoleName = "admin";

                var user = new IdentityUser()
                {
                    UserName = form.Email,
                    Email = form.Email
                };

                var user_response = await _userManager.CreateAsync(user, form.Password);
                if (user_response.Succeeded)
                {
                    var profile = new UserProfile()
                    {
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        StreetName = form.StreetName,
                        PostalCode = form.PostalCode,
                        City = form.City,
                        Country = form.Country
                    };

                    var profile_repsonse = await _profileManager.CreateAsync(user, profile);
                    if (profile_repsonse.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(user, form.RoleName);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        if (form.ReturnUrl == null || form.ReturnUrl == "/")
                            return RedirectToAction("Index", "Home");
                        else
                            return LocalRedirect(form.ReturnUrl);

                    }
                    else
                    {
                        form.ErrorMessage = profile_repsonse.Message;
                    }
                }
            }

            

            return View(form);
        }


        #endregion


        #region SignIn 

        [HttpGet]
        [Route("signin")]
        public IActionResult SignIn(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new SignInForm();
            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }


        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if(ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(form.Email, form.Password, isPersistent: false, false);
                if (res.Succeeded)
                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);    
            }
            
            form.ErrorMessage = "Incorrect email or password";

            return View(form);
        }

        #endregion


    }
}
