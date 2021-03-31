using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    // Confirm that customer is Charged for the pickup


    // Select Customer Profile and see their address on a map

    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public IActionResult Index(int? value, Customer customer)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem()
            {
                Text = "Monday",
                Value = "Monday",
                Selected = false
            };
            SelectListItem item2 = new SelectListItem()
            {
                Text = "Tuesday",
                Value = "tuesday",
                Selected = false
            };
            SelectListItem item3 = new SelectListItem()
            {
                Text = "Wednesday",
                Value = "Wednesday",
                Selected = false
            };
            SelectListItem item4 = new SelectListItem()
            {
                Text = "Thursday",
                Value = "Thursday",
                Selected = false
            };

            SelectListItem item5 = new SelectListItem()
            {
                Text = "Friday",
                Value = "Friday",
                Selected = false
            };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

            ViewBag.List = items;

            if(value != null)
            {
                items.Where(i => i.Value == value.ToString()).FirstOrDefault().Selected = true;
            }        

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
        //public async Task<IActionResult> Details(int? id)
        //{
        //    //var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
        //    //return View(customer);

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(c => c.Address)
        //        .Include(c => c.PickupDay)
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);

        //    ViewData["APIkeys"] = APIkeys.GOOGLE_API_KEY;

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);

        //}
    

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee )
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
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
           
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }       
        public IActionResult Charge(int id)
        {
            try
            {
                var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
                customer.AmountOwed += 25;
                customer.LastPickupDay = DateTime.Now;
                customer.IsPickupConfirmed = "Yes";
                _context.Customers.Update(customer);
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



