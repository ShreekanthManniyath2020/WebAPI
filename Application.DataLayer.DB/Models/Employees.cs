using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataLayer.DB.Models
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
        }

        [BsonId]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string EmailId { get; set; }

        public string Image { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public DateTime Entereddate { get; set; }

        public int IsActive { get; set; }
    }
}
