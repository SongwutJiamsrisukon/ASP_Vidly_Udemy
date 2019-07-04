using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_Vidly_Udemy.Models;//see models
using ASP_Vidly_Udemy.ViewModels;
using System.Data.Entity;


namespace ASP_Vidly_Udemy.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;//declare property for DbConnection 
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();//delete after used(same db.closed())
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id); ;

            return View(movies);
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