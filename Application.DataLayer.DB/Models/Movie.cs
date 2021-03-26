using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataLayer.DB.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid().ToString();
        }

        [BsonId]
        public string Id { get; set; }
        public string plot;
        public IEnumerable<string> genres;
        public int runtime;
        public IEnumerable<string> cast;
        public dynamic title;
        public string fullplot;
        public IEnumerable<string> languages;
        public DateTime released;
        public DateTime lastupdated;        
        public IEnumerable<string> directors;
        public IEnumerable<string> writers;
        public IEnumerable<Award>  awards;
        public int year;
        public Imdb imdb;
        public IEnumerable<string> countries;
        public string type;
        public Tomato tomatoes;
    }

    [BsonIgnoreExtraElements]
    public class TomatoViewer
    {
        public float rating;
        public int numReviews;
        public int meter;
    }
    [BsonIgnoreExtraElements]
    public class Tomato
    {
        public TomatoViewer viewer;
        public string production;
        public DateTime lastUpdated;
    }

    [BsonIgnoreExtraElements]
    public class Award
    {
        public int wins;
        public int nominations;
        public string text;
    }
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        public decimal rating;
        public int votes;
        public int id;
    }
}
