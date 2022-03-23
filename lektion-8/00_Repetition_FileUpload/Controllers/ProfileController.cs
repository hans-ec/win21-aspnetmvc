using _00_Repetition_FileUpload.Models;
using _00_Repetition_FileUpload.Models.Entitites;
using _00_Repetition_FileUpload.Models.Forms;
using _00_Repetition_FileUpload.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _00_Repetition_FileUpload.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SqlContext _context;
        private readonly IWebHostEnvironment _host;

        public ProfileController(SqlContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        [Route("profile/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var viewModel = new ProfileViewModel();

            var userProfileEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            viewModel.Profile = new UserProfile
            {
                UserId = userProfileEntity.UserId,
                FirstName = userProfileEntity.FirstName,
                LastName = userProfileEntity.LastName,
                Email = userProfileEntity.Email
            };

            var profileImageEntity = await _context.ProfileImages.FirstOrDefaultAsync(x => x.UserId == id);
            viewModel.ProfileImage = new UserProfileImage
            {
                FileName = profileImageEntity.FileName
            };

            return View(viewModel);
        }







        [Route("profile/edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var userProfileEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            var userProfile = new UserProfile
            {
                FirstName = userProfileEntity.FirstName,
                LastName = userProfileEntity.LastName,
                Email = userProfileEntity.Email
            };

            return View(userProfile);
        }

        [Route("profile/edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserProfile profile)
        {
            try
            {
                var userProfileEntity = new UserProfileEntity
                {
                    UserId = id,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Email = profile.Email
                };

                _context.UserProfiles.Update(userProfileEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Profile", new { id = id });
            }
            catch
            {
                return View(profile);
            }
        }












        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(ProfileImageUploadForm form)
        {
            var userId = "570c12e1-17da-4a9e-9a9d-ddb18cb30017";

            if (ModelState.IsValid)
            {
                var profileImageEntity = new ProfileImageEntity
                {
                    FileName = $"{userId}_{form.File.FileName}",
                    UserId = userId
                };

                string filePath = Path.Combine($"{_host.WebRootPath}/profileImages", profileImageEntity.FileName);

                // upload file to server/filePath
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await form.File.CopyToAsync(fs);
                }

                // save to database
                _context.ProfileImages.Add(profileImageEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }
    }
}
