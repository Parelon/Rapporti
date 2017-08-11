using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rapporti.Data;
using Rapporti.Models;

namespace Rapporti.Controllers
{
    public class GruppiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GruppiController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Gruppoe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gruppi.ToListAsync());
        }

        // GET: Gruppoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppo = await _context.Gruppi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gruppo == null)
            {
                return NotFound();
            }

            return View(gruppo);
        }

        // GET: Gruppoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gruppoe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Gruppo gruppo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruppo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gruppo);
        }

        // GET: Gruppoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppo = await _context.Gruppi.SingleOrDefaultAsync(m => m.Id == id);
            if (gruppo == null)
            {
                return NotFound();
            }
            return View(gruppo);
        }

        // POST: Gruppoe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Gruppo gruppo)
        {
            if (id != gruppo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruppo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruppoExists(gruppo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(gruppo);
        }

        // GET: Gruppoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppo = await _context.Gruppi
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gruppo == null)
            {
                return NotFound();
            }

            return View(gruppo);
        }

        // POST: Gruppoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gruppo = await _context.Gruppi.SingleOrDefaultAsync(m => m.Id == id);
            _context.Gruppi.Remove(gruppo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GruppoExists(int id)
        {
            return _context.Gruppi.Any(e => e.Id == id);
        }
    }
}
