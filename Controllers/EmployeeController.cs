using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrashCollector.ActionFilters;
using TrashCollector.Data;
using TrashCollector.Models;


namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]

    // default view should be today's pickups 
    // should show extra pickup 
    // should show suspended service

    // Select day to see who has a pickup for that day 


    // Confirm that the employee completed the pickup 
    // Confirm that customer is charged for the pickup


    // Select Customer Profile and see their address on a map

    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public IActionResult Index()
        { 

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }
            string currentDayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var customersWithSameZip = _context.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();
            var customersWithSameDay = customersWithSameZip.Where(c => c.PickupDay == currentDayOfWeek).ToList();
            var customersWithSuspendedDays = customersWithSameDay.Where(c => c.StartSuspensionDay.ToString() == currentDayOfWeek && c.EndSuspensionDay.ToString() == currentDayOfWeek).ToList();
            var NewSet = customersWithSameDay.Except(customersWithSuspendedDays);
            return View(NewSet);
          }

// GET: EmployeeController/Details/5
public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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


        public IActionResult ChargeCustomer(int id)
        {
            var chargeId = _context.Customers.Find(id);
            return View(chargeId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult ChargeCustomer(Models.Customer customer)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                customer.AmountOwed += 25;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return View();
            }
        }

    }
}



