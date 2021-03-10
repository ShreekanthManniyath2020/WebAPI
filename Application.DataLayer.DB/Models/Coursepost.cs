using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataLayer.DB.Models
{
    public class Coursepost
    {
        public Coursepost()
        {
            Id = Guid.NewGuid().ToString();
        }

        [BsonId]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Sort_Desc { get; set; }

        public string Full_Desc { get; set; }

        public string Image { get; set; }

        public string Author { get; set; }

        public DateTime EnteredDate { get; set; }

        public int IsActive { get; set; }
    }
}