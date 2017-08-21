using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rapporti.Data;
using Rapporti.Models;
using Rapporti.Models.AssegnazioniViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Rapporti.Controllers
{
    [Authorize]
    public class AssegnazioniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssegnazioniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assegnazioni
        public async Task<IActionResult> Index()
        {
            List<IndexAssegnazioneViewModel> model = new List<IndexAssegnazioneViewModel>();
            //var applicationDbContext = _context.Assegnazioni.Include(a => a.Gruppo).Include(a => a.Utente);
            foreach (var user in await _context.Users.ToListAsync())
            {
                var groupedByUser = _context.Assegnazioni.Include(a => a.Gruppo).Include(a => a.Utente).Where(a => a.Utente == user).Select(a => a.Gruppo.Nome);
                model.Add(new IndexAssegnazioneViewModel()
                {
                    ID = user.Id,
                    UserName = user.UserName,
                    Gruppi = await groupedByUser.ToListAsync()
                });
            }

            return View(model);
        }

        // GET: Assegnazioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assegnazione = await _context.Assegnazioni
                .Include(a => a.Gruppo)
                .Include(a => a.Utente)
                .Where(m => m.Utente.Id == id).ToListAsync();
            if (assegnazione == null)
            {
                return NotFound();
            }
            ViewData["UtenteId"] = id;
            return View(assegnazione);
        }

        // GET: Assegnazioni/Create
        public async Task<IActionResult> Create()
        {
            List<CreateViewModel> model = new List<CreateViewModel>();
            foreach (var utente in await _context.Users.ToListAsync())
            {
                model.Add(new CreateViewModel
                {
                    ID = utente.Id,
                    Nome = utente.UserName,
                    Selezionato = false
                });
            }
            ViewData["Gruppi"] = _context.Gruppi.ToList();
            ViewData["Title"] = "Assegna utenti a un gruppo";
            return View(model);
        }

        // POST: Assegnazioni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int gruppoID, List<CreateViewModel> model)
        {
            if (ModelState.IsValid)
            {
                Gruppo gruppo = await _context.Gruppi.FindAsync(gruppoID);
                foreach (var utente in model)
                {
                    if (utente.Selezionato)
                        await _context.AddAsync(new Assegnazione { Gruppo = gruppo, Utente = await _context.Users.FindAsync(utente.ID) });
                    else
                        _context.Assegnazioni.Remove( await _context.Assegnazioni.SingleOrDefaultAsync(a => a.GruppoId == gruppoID && a.UtenteId == utente.ID));
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Assegnazioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<CreateViewModel> model = new List<CreateViewModel>();
            foreach (var item in await _context.Gruppi.ToListAsync())
            {
                var assegnazione = await _context.Assegnazioni.SingleOrDefaultAsync(a => a.UtenteId == id && a.GruppoId == item.Id);
                if (assegnazione == null)
                    model.Add(new CreateViewModel() { ID = 0, Nome = item.Nome, Selezionato = false });
                else
                    model.Add(new CreateViewModel() { ID = assegnazione.Id, Nome = item.Nome, Selezionato = true });
            }

            ViewData["UtenteUserName"] = _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            ViewData["UtenteId"] = id;
            return View(model);
        }

        // POST: Assegnazioni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, List<CreateViewModel> model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    if (item.ID == 0 && item.Selezionato)
                    {
                        var assegnazione = new Assegnazione();
                        assegnazione.UtenteId = id;
                        assegnazione.Gruppo = await _context.Gruppi.SingleAsync(g => g.Nome == item.Nome);
                        await _context.Assegnazioni.AddAsync(assegnazione);
                    }
                    else if(item.ID != 0 && !item.Selezionato)
                    {
                        _context.Remove(await _context.Assegnazioni.SingleAsync(a => a.Id == item.ID));
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["UtenteId"] = id;
            return View(model);
        }

        // GET: Assegnazioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["UtenteId"] = id;
            var assegnazioni = await _context.Assegnazioni
                .Include(a => a.Gruppo)
                .Include(a => a.Utente)
                .Where(m => m.Utente.Id == id).ToListAsync();
            if (assegnazioni == null)
            {
                return NotFound();
            }

            return View(assegnazioni);
        }

        // POST: Assegnazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assegnazioni = await _context.Assegnazioni.Where(m => m.Utente.Id == id).ToListAsync();
            foreach (var item in assegnazioni)
                _context.Assegnazioni.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AssegnazioneExists(int id)
        {
            return _context.Assegnazioni.Any(e => e.Id == id);
        }
    }
}
