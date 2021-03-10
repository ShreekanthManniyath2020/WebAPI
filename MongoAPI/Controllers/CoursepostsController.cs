using Application.DataLayer.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MongoAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class CoursepostsController : BaseController
    {
        private const string COURSEPOSTSTABLE = "Courseposts";

        // GET: api/Courseposts
        [HttpGet]
        public IEnumerable<Coursepost> Get()
        {
            return db.Get<Coursepost>(COURSEPOSTSTABLE);
        }

        // GET: api/Courseposts/5
        [HttpGet("{id}", Name = "GetCoursePosts")]
        public IActionResult Get(string id)
        {
            var coursepost = db.GetById<Coursepost>(COURSEPOSTSTABLE, id);
            if (coursepost != null)
            {
                return Ok(coursepost);
            }
            return NotFound($"coursepost with Id:{id} was not found");
        }

        // POST: api/Courseposts
        [HttpPost]
        public IActionResult Post(Coursepost coursepost)
        {
            coursepost = new Coursepost
            {
                Author = coursepost.Author,
                Image = coursepost.Image,
                Full_Desc = coursepost.Full_Desc,
                IsActive = coursepost.IsActive,
                Sort_Desc = coursepost.Sort_Desc,
                Title = coursepost.Title,
                EnteredDate = DateTime.Now
            };

            db.insertRecord(COURSEPOSTSTABLE, coursepost);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + coursepost.Id, coursepost);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="coursepost"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Path(Coursepost coursepost)
        {
            db.UpsertRecord(COURSEPOSTSTABLE, coursepost.Id, coursepost);
            return Ok(coursepost);
        }

        // PUT: api/Courseposts/5
        [HttpPut("{id}")]
        public IActionResult Put(Coursepost coursepost)
        {
            db.UpsertRecord(COURSEPOSTSTABLE, coursepost.Id, coursepost);
            return Ok(coursepost);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = db.Delete<Coursepost>(COURSEPOSTSTABLE, id);
            return Ok(result.DeletedCount);
        }
    }
}