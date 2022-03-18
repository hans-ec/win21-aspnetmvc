#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01_FileUploading;
using _01_FileUploading.Models.Entitites;
using _01_FileUploading.Models;

namespace _01_FileUploading.Controllers
{
    public class ImagesController : Controller
    {
        private readonly SqlContext _context;
        private readonly IWebHostEnvironment _host;

        public ImagesController(SqlContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }








        // GET: Images
        public async Task<IActionResult> Index()
        {
            var items = new List<ImageModel>();

            foreach(var item in await _context.Images.ToListAsync())
            {
                items.Add(new ImageModel
                {
                    Id = item.Id,
                    FriendlyFileName = $"{item.FileName.Split("_")[0]}.{item.FileName.Split(".")[1]}",
                    FileName = item.FileName,
                    File = item.File
                });
            }

            return View(items);
        }









        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageEntity = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageEntity == null)
            {
                return NotFound();
            }

            return View(imageEntity);
        }














        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageEntity imageEntity)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = _host.WebRootPath;
                string fileName = $"{Path.GetFileNameWithoutExtension(imageEntity.File.FileName)}_{Guid.NewGuid()}{Path.GetExtension(imageEntity.File.FileName)}";
                string filePath = Path.Combine($"{wwwrootPath}/images", fileName);

                // uploading file to server
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await imageEntity.File.CopyToAsync(fs);
                }

                // saving file information to database
                imageEntity.FileName = fileName;
                _context.Add(imageEntity);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            return View(imageEntity);
        }
















        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageEntity = await _context.Images.FindAsync(id);
            if (imageEntity == null)
            {
                return NotFound();
            }
            return View(imageEntity);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName")] ImageEntity imageEntity)
        {
            if (id != imageEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageEntityExists(imageEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageEntity);
        }













        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageEntity = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageEntity == null)
            {
                return NotFound();
            }

            return View(imageEntity);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageEntity = await _context.Images.FindAsync(id);
            _context.Images.Remove(imageEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageEntityExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
