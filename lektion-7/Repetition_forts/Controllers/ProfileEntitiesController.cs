#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repetition_forts;
using Repetition_forts.Models.Entities;

namespace Repetition_forts.Controllers
{
    public class ProfileEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfileEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Profiles.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfileEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileEntity == null)
            {
                return NotFound();
            }

            return View(profileEntity);
        }

        // GET: ProfileEntities/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ProfileEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetName,PostalCode,City,Country,UserId")] ProfileEntity profileEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileEntity.UserId);
            return View(profileEntity);
        }

        // GET: ProfileEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles.FindAsync(id);
            if (profileEntity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileEntity.UserId);
            return View(profileEntity);
        }

        // POST: ProfileEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetName,PostalCode,City,Country,UserId")] ProfileEntity profileEntity)
        {
            if (id != profileEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileEntityExists(profileEntity.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileEntity.UserId);
            return View(profileEntity);
        }

        // GET: ProfileEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileEntity = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileEntity == null)
            {
                return NotFound();
            }

            return View(profileEntity);
        }

        // POST: ProfileEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileEntity = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(profileEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileEntityExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
