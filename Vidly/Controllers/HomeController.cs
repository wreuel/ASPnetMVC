﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       //// [Route("Customers/Details/{month:regex(\\d)}")]
       // public ActionResult Customers()
       // {
       //     //var customers = new List<Customer>
       //     //{
       //     //    new Customer{Name = "Customer 1" },
       //     //    new Customer{Name = "Customer 2" }
       //     //};

       //     //return View(customers);
            
       // }
    }
}