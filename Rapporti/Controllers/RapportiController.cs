using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rapporti.Data;
using Rapporti.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Rapporti.Controllers
{
    [Authorize]
    public class RapportiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utente> _manager;

        public RapportiController(ApplicationDbContext context, UserManager<Utente> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Rapporti
        public async Task<IActionResult> Index()
        {
            var user = await _manager.GetUserAsync(User);
            var myGroups = await _context.Assegnazioni.Where(a => a.UtenteId == user.Id).Include(a => a.Gruppo).Select(g => g.GruppoId).ToListAsync();
            var model = _context.Rapporti
                .Include(r => r.Autore)
                .Include(g => g.Gruppo)
                .Include(d => d.Destinatario)
                .Where(a => a.AutoreId == user.Id || a.DestinatarioId == user.Id || (myGroups.Contains(a.GruppoId) && a.DestinatarioId == null));
            return View(model.Distinct().ToList());
        }

        // GET: Rapporti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapporto = await _context.Rapporti
                .Include(r => r.Autore)
                .Include(r => r.Gruppo)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rapporto == null)
            {
                return NotFound();
            }

            return View(rapporto);
        }

        // GET: Rapporti/Create
        public IActionResult Create()
        {
            ViewData["GruppoId"] = new SelectList(_context.Gruppi, "Id", "Nome");
            ViewData["DestinatarioId"] = new SelectList(_context.Users, "Id", "Nome");
            return View();
        }

        // POST: Rapporti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int destinatarioId, [Bind("Id,Testo,GruppoId")] Rapporto rapporto)
        {
            if (_context.Assegnazioni.Count(a => a.GruppoId == rapporto.GruppoId && a.UtenteId == destinatarioId) > 0)
            {
                rapporto.Data = DateTime.Now.Date;
                rapporto.Autore = await _manager.GetUserAsync(User);
                rapporto.Gruppo = await _context.Gruppi.FindAsync(rapporto.GruppoId);
                if (destinatarioId != 0)
                    rapporto.Destinatario = await _context.Users.FindAsync(destinatarioId);
                await _context.AddAsync(rapporto);
                if (await _context.SaveChangesAsync() > 0)
                    return RedirectToAction("Index");
            }
            else
                ViewData["Errore"] = "Il destinatario non fa parte del gruppo.";
            ViewData["DestinatarioId"] = new SelectList(_context.Users, "Id", "Nome", rapporto.DestinatarioId);
            ViewData["GruppoId"] = new SelectList(_context.Gruppi, "Id", "Nome", rapporto.GruppoId);
            return View(rapporto);
        }

        // GET: Rapporti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapporto = await _context.Rapporti
                .Include(m => m.Autore)
                .Include(m => m.Gruppo)
                .Include(m => m.Destinatario)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rapporto == null)
            {
                return NotFound();
            }
            ViewBag.Gruppi = new SelectList(_context.Gruppi, "Id", "Nome", rapporto.GruppoId);

            return View(rapporto);
        }

        // POST: Rapporti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Testo,AutoreUtenteId,GruppoId")] Rapporto rapporto)
        {
            if (id != rapporto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapporto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportoExists(rapporto.Id))
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
            ViewData["AutoreUtenteId"] = new SelectList(_context.Users, "Id", "Id", rapporto.AutoreId);
            ViewData["GruppoId"] = new SelectList(_context.Gruppi, "Id", "Id", rapporto.GruppoId);
            //ViewData["SoggettoUtenteId"] = new SelectList(_context.Users, "Id", "Id", rapporto.SoggettoUtenteId);
            return View(rapporto);
        }

        // GET: Rapporti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapporto = await _context.Rapporti
                .Include(r => r.Autore)
                .Include(r => r.Gruppo)
                .Include(r => r.Destinatario)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rapporto == null)
            {
                return NotFound();
            }

            return View(rapporto);
        }

        // POST: Rapporti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapporto = await _context.Rapporti.SingleOrDefaultAsync(m => m.Id == id);
            _context.Rapporti.Remove(rapporto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RapportoExists(int id)
        {
            return _context.Rapporti.Any(e => e.Id == id);
        }
    }
}
