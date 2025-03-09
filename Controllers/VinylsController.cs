using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopDomain.Model;
using ShopInfrastructure;

namespace ShopInfrastructure.Controllers
{
    public class VinylsController : Controller
    {
        private readonly LabProjectContext _context;

        public VinylsController(LabProjectContext context)
        {
            _context = context;
        }

        // GET: Vinyls
        public async Task<IActionResult> Index()
        {
            var labProjectContext = _context.Vinyls.Include(v => v.Artist).Include(v => v.Genre);
            return View(await labProjectContext.ToListAsync());
        }

        // GET: Vinyls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyls
                .Include(v => v.Artist)
                .Include(v => v.Genre)
                .FirstOrDefaultAsync(m => m.VinilId == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // GET: Vinyls/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Vinyls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VinilId,VinilName,ArtistId,GenreId,Price,Stock")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vinyl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", vinyl.GenreId);
            return View(vinyl);
        }

        // GET: Vinyls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyls.FindAsync(id);
            if (vinyl == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", vinyl.GenreId);
            return View(vinyl);
        }

        // POST: Vinyls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VinilId,VinilName,ArtistId,GenreId,Price,Stock")] Vinyl vinyl)
        {
            if (id != vinyl.VinilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinyl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinylExists(vinyl.VinilId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName", vinyl.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", vinyl.GenreId);
            return View(vinyl);
        }

        // GET: Vinyls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vinyl = await _context.Vinyls
                .Include(v => v.Artist)
                .Include(v => v.Genre)
                .FirstOrDefaultAsync(m => m.VinilId == id);
            if (vinyl == null)
            {
                return NotFound();
            }

            return View(vinyl);
        }

        // POST: Vinyls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vinyl = await _context.Vinyls.FindAsync(id);
            if (vinyl != null)
            {
                _context.Vinyls.Remove(vinyl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinylExists(int id)
        {
            return _context.Vinyls.Any(e => e.VinilId == id);
        }
    }
}
