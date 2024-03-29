﻿using ASP_Vidly_Udemy.Dtos;
using ASP_Vidly_Udemy.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.Entity;

namespace ASP_Vidly_Udemy.Controllers.Api
{
    public class MoviesController : ApiController
    {

        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)//optional parameter use in Views at New.cshtml in Rentals (send by typeahead plugin)
        {
            var moviesQuery = _context.Movies.Include(c => c.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrEmpty(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDbo = moviesQuery.ToList().Select(Mapper.Map<Movie,MovieDto>);

            return Ok(movieDbo);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if(movie == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movie);


            _context.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
