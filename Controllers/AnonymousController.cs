using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class AnonymousController : Controller
    {
        private ApplicationDbContext _context;

        public AnonymousController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Anonymous
        public ActionResult Index()
        {
    
            return View();
        }

        // GET: Anonymous/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Anonymous/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anonymous/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anonymous anonymous)
        {
            try
            {

                _context.Anonymous.Add(anonymous);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Anonymous/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Anonymous/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Anonymous/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Anonymous/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
