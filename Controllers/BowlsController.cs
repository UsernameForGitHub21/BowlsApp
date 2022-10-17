using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BowlsApp.Data;
using BowlsApp.Models;

namespace BowlsApp.Controllers
{
    public class BowlsController : Controller
    {
        private readonly BowlsAppContext _context;

        public BowlsController(BowlsAppContext context)
        {
            _context = context;
        }

        // GET: Bowls
        public async Task<IActionResult> Index(string bowlGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Bowl
                                            orderby m.Genre
                                            select m.Genre;

            var bowls = from m in _context.Bowl
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                bowls = bowls.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bowlGenre))
            {
                bowls = bowls.Where(x => x.Genre == bowlGenre);
            }

            var bowlGenreVM = new BowlGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Bowls = await bowls.ToListAsync()
            };

            return View(bowlGenreVM);
        }

        // GET: Bowls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowl == null)
            {
                return NotFound();
            }

            return View(bowl);
        }

        // GET: Bowls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Bowl bowl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowl);
        }

        // GET: Bowls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl.FindAsync(id);
            if (bowl == null)
            {
                return NotFound();
            }
            return View(bowl);
        }

        // POST: Bowls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Bowl bowl)
        {
            if (id != bowl.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlExists(bowl.ID))
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
            return View(bowl);
        }

        // GET: Bowls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowl == null)
            {
                return NotFound();
            }

            return View(bowl);
        }

        // POST: Bowls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowl = await _context.Bowl.FindAsync(id);
            _context.Bowl.Remove(bowl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlExists(int id)
        {
            return _context.Bowl.Any(e => e.ID == id);
        }
    }
}
