using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataLayer.DB;
using Application.DataLayer.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MongoAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : BaseController
    {
        private const string EMPLOYEETABLE = "Employees";
        public EmployeesController()
        {
             
        }

        // GET: api/employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return db.Get<Employee>(EMPLOYEETABLE);
        }

        // GET: api/sample/21c10c57-64f3-4a05-ab94-f91c0340de15
        [HttpGet("{id}", Name = "GetEmployees")]
        public IActionResult Get(string id)
        {
            var employee = db.GetById<Employee>(EMPLOYEETABLE, id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id:{id} was not found");
        }

        // POST: api/sample
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            employee = new Employee{ FirstName = employee.FirstName, Lastname = employee.Lastname, EmailId = employee.EmailId, IsActive = 1, Password = employee.Password, Role = employee.Role, Entereddate = DateTime.Now};
            db.insertRecord(EMPLOYEETABLE, employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        // PUT: api/sample/5
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            db.UpsertRecord(EMPLOYEETABLE, employee.Id, employee);
            return Ok(employee);
        }

        //[HttpPatch("{id}")]
        //public IActionResult Path(Employee employee)
        //{
        //    db.UpsertRecord(EMPLOYEETABLE, employee.Id, employee);
        //    return Ok(employee);
        //}


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
           var result = db.Delete<Employee>(EMPLOYEETABLE, id);
            return Ok(result.DeletedCount);
        }
    }
}