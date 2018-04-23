using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = new List<Customer>
            //{
            //    new Customer{Name = "John Smith", Id = 1 },
            //    new Customer{Name = "Marie", Id =2 }
            //};

            var customers = GetCustomers();
            //retorno.Customers = customers;

            return View(customers);


        }

        //[Route("movies/released/{year:regex(\\d{2})}/{month:regex(\\d{2}):range(1, 12)}")]
        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            /*var customer = new Customer();
            if (id == 1)
            {
                customer.Name = "John Smith";
            }
            else if (id == 2)
            {
                customer.Name = "Marie";
            }
            else
            {
                customer.Name = "Cliente não existe";
            }
            return View(customer);*/

            var customer = GetCustomers().SingleOrDefault(s => s.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}