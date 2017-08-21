using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapporti.Data;
using Rapporti.Models;

namespace Rapporti.Controllers
{
    public class CompitiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompitiController(ApplicationDbContext context)
        {
            _context = context;            
        }

        // GET: Compiti
        public async Task<IActionResult> Index()
        {
            return View(_context.Compiti.GroupBy(c => c.UtenteId));
        }

        public async Task<IActionResult> Clear()
        {
            foreach(Compito compito in _context.Compiti)
            {
                _context.Remove(compito);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Compiti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compiti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compiti/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                foreach (string userId in collection["utenti"])
                {
                    Compito compito = new Compito();
                    compito.UtenteId = userId;
                    compito.GruppoId = collection["gruppo"];
                    _context.Add(compito);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Compiti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compiti/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compiti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compiti/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}