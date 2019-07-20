using ASP_Vidly_Udemy.Dtos;
using ASP_Vidly_Udemy.Models;
using System;
using System.Linq;

using System.Web.Http;

namespace ASP_Vidly_Udemy.Controllers.Api
{
    public class RentalsController : ApiController
    {
        public ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalCustomerMovieDto rentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            //ไม่จำเป็นต้อง if(customer == null) เพราะไม่ใช่ external api(public api) เราจึงสามารถดักข้อมูลจากหน้าบ้านได้

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();//query before loop
            //Can't use _context.Movies.Where(m => m.Id.Contains(rentalDto.MovieIds)).ToList(); because m.Id is not list
            //SELECT * FROM Movies WHERE Id IN (1,2,3...)

            foreach (var movie in movies)
            {
                //var movie = _context.Movies.Single(m => m.Id == rentalDto.MovieIds[i]); many query this is bad code

                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rentalCustomerMovie = new RentalCustomerMovie {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.RentalCustomerMovies.Add(rentalCustomerMovie);

            }
            _context.SaveChanges();
            return Ok();//not return Created(new Uri(Request.RequestUri + "/" +rentalCustomerMovie.Id));
                        //because this action create multiple object not single
        }
    }
}