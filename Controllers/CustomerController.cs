using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrashCollector.Data;
using TrashCollector.Models;
using Customer = TrashCollector.Models.Customer;

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            if (customer.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(customer);
            }

        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);

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

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: CustomerController/Delete/5
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Models.Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        //Added for Payment
        //        [Route("Pay")]
        //        public async Task<dynamic> Pay(Models.Payment payment)
        //        {
        //            return await MakePayment.PayAsync(payment.CardNumber, payment.Month, payment.Year, payment.Cvc, payment.Value);
        //        }

        //        public static async Task<dynamic> PayAsync(string CardNumber, int Month, int Year, string Cvc, int Value)
        //        {
        //            try
        //            {
        //                StripeConfiguration.ApiKey = "sk_test_51IWr81I0mwyrhuJbwUsyQcLNrQKVQ508xWWR4I1lIh8fnMUaHk61JpUaZcI31wo2uEmAAAYge4L04dVBW0b7A9BH00BvfmxoVY";
        //                var optionstoken = new TokenCreateOptions
        //                {
        //                    Card = new TokenCardOptions
        //                    {
        //                        Number = CardNumber,
        //                        ExpMonth = Month,
        //                        ExpYear = Year,
        //                        Cvc = Cvc

        //                    }
        //                };
        //                var servicetoken = new TokenService();
        //                Token stripetoken = await servicetoken.CreateAsync(optionstoken);
        //                var options = new ChargeCreateOptions
        //                {
        //                    Amount = Value,
        //                    Currency = "usd",
        //                    Description = "test",
        //                    Source = stripetoken.Id
        //                };

        //                var service = new ChargeService();
        //                Charge charge = await service.CreateAsync(options);
        //                if (charge.Paid)
        //                {
        //                    return "Success";
        //                }
        //                else
        //                {
        //                    return "Failed";
        //                }
        //            }

        //            catch (Exception e)
        //            {
        //                return e.Message;
        //            }
        //        }
        //    }
        //}


    }
}
