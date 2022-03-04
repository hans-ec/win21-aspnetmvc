// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using _02_Identity_Custom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _02_Identity_Custom.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required(ErrorMessage = "Du måste ange ett förnamn.")]
            [Display(Name = "Förnamn")]
            [StringLength(256, ErrorMessage = "{0}et måste minst innehålla {2} tecken.", MinimumLength = 2)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Du måste ange ett efternamn.")]
            [Display(Name = "Efternamn")]
            [StringLength(256, ErrorMessage = "{0}et måste minst innehålla {2} tecken.", MinimumLength = 2)]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Du måste ange en postadress.")]
            [Display(Name = "Postadress")]
            [StringLength(256, ErrorMessage = "{0}en måste minst innehålla {2} tecken.", MinimumLength = 2)]
            public string AddressLine { get; set; }

            [Required(ErrorMessage = "Du måste ange ett postnummer.")]
            [Display(Name = "Postnummer")]
            [StringLength(5, ErrorMessage = "{0}et måste bestå av bestå {2} tecken. (12345)", MinimumLength = 5)]
            public string PostalCode { get; set; }

            [Required(ErrorMessage = "Du måste ange en ort.")]
            [Display(Name = "Ort")]
            [StringLength(256, ErrorMessage = "{0}en måste minst innehålla {2} tecken.", MinimumLength = 2)]
            public string City { get; set; }

            [Phone]
            [Display(Name = "Telefonnummer")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressLine = user.AddressLine,
                PostalCode = user.PostalCode,
                City = user.City,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);




            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if(Input.FirstName != user.FirstName)
                user.FirstName = Input.FirstName;


            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
