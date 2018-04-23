using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{ 
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1" },
                new Customer{Name = "Customer 2" }
            };
            //ViewData["Movie"] = movie;

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return View(movie);
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { Name = "Sherk", Id = 1 });
            movies.Add(new Movie() { Name = "Wall-e", Id = 2 });


            return View(movies);
        }



        [Route("movies/released/{year:regex(\\d{2})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year+"/"+month);
        }
        
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return (Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy)));
        }*/
    }
}