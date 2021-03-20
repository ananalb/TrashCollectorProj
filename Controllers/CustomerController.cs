using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]

    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            var customers1 = _context.Customers.Include(c => c.IdentityUser).ToList();
            return View(customers1);
        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.IdentityUser).FirstOrDefault(c => c.CustomerId == id);
            return RedirectToAction("Create", new { id = customer.CustomerId });
            //return View();
        }

        // GET: CustomerController/Create
        [HttpGet]
        public IActionResult Create()
        {

            
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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

        //Added
        [Route("Pay")]
        public async Task<dynamic> Pay(Models.Payment payment)
        {
            return await MakePayment.PayAsync(payment.CardNumber, payment.Month, payment.Year, payment.Cvc, payment.Value);
        }
    }
}
