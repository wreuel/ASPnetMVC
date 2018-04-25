using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
                

            }
            else
            {
                var customerIndB = _context.Customers.Single(c => c.Id == customer.Id);

                customerIndB.Name = customer.Name;
                customerIndB.Birthdate = customer.Birthdate;
                customerIndB.MembershipTypeId = customer.MembershipTypeId;
                customerIndB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
                
                //TryUpdateModel(customerIndB); //
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");
        }

        
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType ).ToList(); //GetCustomers();
            
            return View(customers);
        }

        //[Route("movies/released/{year:regex(\\d{2})}/{month:regex(\\d{2}):range(1, 12)}")]
        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id); //GetCustomers().SingleOrDefault(s => s.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }


        
    }
}