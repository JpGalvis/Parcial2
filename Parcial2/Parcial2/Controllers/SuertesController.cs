using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;

namespace Parcial2.Controllers
{
    public class SuertesController : Controller
    {
        private readonly AppDbContext _context;

        public SuertesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Suertes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suertes.ToListAsync());
        }

        // GET: Suertes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suerte = await _context.Suertes
                .FirstOrDefaultAsync(m => m.futuro == id);
            if (suerte == null)
            {
                return NotFound();
            }

            return View(suerte);
        }

        // GET: Suertes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suertes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("futuro,vision,link")] Suerte suerte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suerte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suerte);
        }

        // GET: Suertes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suerte = await _context.Suertes.FindAsync(id);
            if (suerte == null)
            {
                return NotFound();
            }
            return View(suerte);
        }

        // POST: Suertes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("futuro,vision,link")] Suerte suerte)
        {
            if (id != suerte.futuro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suerte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuerteExists(suerte.futuro))
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
            return View(suerte);
        }

        // GET: Suertes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suerte = await _context.Suertes
                .FirstOrDefaultAsync(m => m.futuro == id);
            if (suerte == null)
            {
                return NotFound();
            }

            return View(suerte);
        }

        // POST: Suertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var suerte = await _context.Suertes.FindAsync(id);
            _context.Suertes.Remove(suerte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuerteExists(string id)
        {
            return _context.Suertes.Any(e => e.futuro == id);
        }
    }
}
