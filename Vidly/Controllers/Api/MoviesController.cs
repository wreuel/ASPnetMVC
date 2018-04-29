using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m =>m.Genre )
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult PostCreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);

                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDto.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
            }
        }


        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            //movieDto.Id = id;
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
            //else
            //{
            //    var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            //    if(movieDto == null)
            //    {
            //        throw new HttpResponseException(HttpStatusCode.NotFound);
            //    }
            //    else
            //    {
            //        Mapper.Map(movieDto, movieInDb);
            //        _context.SaveChanges();
            //    }
            //}

            movieDto.DateAdded = DateTime.Now;

            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }
        }

    }
}
