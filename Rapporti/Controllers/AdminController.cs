using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rapporti.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admintroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admintroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admintroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admintroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admintroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admintroller/Edit/5
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

        // GET: Admintroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admintroller/Delete/5
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