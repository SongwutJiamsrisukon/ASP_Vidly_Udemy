using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_Vidly_Udemy.Models;//see models
using ASP_Vidly_Udemy.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = genre
            };

            return View("MovieForm", movieFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var genre = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genre
            };

            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
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