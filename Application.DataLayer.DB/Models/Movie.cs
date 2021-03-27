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
        public string Plot { get; set; }
        public string Poster { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public int Runtime { get; set; }
        public IEnumerable<string> Cast { get; set; }
        public dynamic Title { get; set; }
        public string Fullplot { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public DateTime Released { get; set; }
        public DateTime Lastupdated { get; set; }
        public IEnumerable<string> Directors { get; set; }
        public IEnumerable<string> Writers { get; set; }
        public IEnumerable<Award> Awards { get; set; }
        public int Year { get; set; }
        public Imdb Imdb { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public string Type { get; set; }
        public Tomato Tomatoes { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class TomatoViewer
    {
        public float Rating { get; set; }
        public int NumReviews { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Tomato
    {
        public TomatoViewer Viewer { get; set; }
        public string Production { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Award
    {
        public int Wins { get; set; }
        public int Nominations { get; set; }
        public string Description { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        public Imdb()
        {
            Id = Guid.NewGuid().ToString();
        }
        public double Rating { get; set; }
        public int Votes { get; set; }
        public string Id { get; set; }
    }
}
