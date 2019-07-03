using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_Vidly_Udemy.Models;//see models
using ASP_Vidly_Udemy.ViewModels;

namespace ASP_Vidly_Udemy.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "AAA" };
            return View(movie);
        }

        public ActionResult Random2()
        {
            ViewBag.MyMovie = new Movie() { Name = "AAA" };
            return View();
        }

        public ActionResult Random3()
        {
            var movie = new Movie() { Name = "AAA" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "C1" },
                new Customer{ Name = "C2" }
            };

            var randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }


    }
}