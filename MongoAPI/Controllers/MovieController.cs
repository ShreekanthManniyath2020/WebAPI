using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataLayer.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : BaseController
    {
        private const string MOVIETABLE = "Movies";
        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return db.Get<Movie>(MOVIETABLE);
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var movie = db.GetById<Movie>(MOVIETABLE, id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound($"movie with Id:{id} was not found");
        }
        // POST: api/Movie
        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            movie = new Movie
            {
                Title = movie.Title,
                Year = movie.Year,
                Runtime = movie.Runtime,
                Released = movie.Released,
                Poster = movie.Poster,
                Plot = movie.Plot,
                Fullplot = movie.Fullplot,
                Lastupdated = DateTime.Now,
                Type = movie.Type,
                Directors = movie.Directors,
                Imdb = movie.Imdb,
                Countries = movie.Countries,
                Genres = movie.Genres,
                Tomatoes = movie.Tomatoes,
                Writers = movie.Writers,
                Languages = movie.Languages
            };
            db.insertRecord(MOVIETABLE, movie);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + movie.Id, movie);
        }
        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public IActionResult Put(Movie movie)
        {
            db.UpsertRecord(MOVIETABLE, movie.Id, movie);
            return Ok(movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = db.Delete<Employee>(MOVIETABLE, id);
            return Ok(result.DeletedCount);
        }
    }
}
