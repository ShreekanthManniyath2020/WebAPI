using Application.DataLayer.DB.Implementation;
using Application.DataLayer.DB.Models;
using System;
using System.Collections.Generic;

namespace APITester
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AngularApplicationDB");
           
            db.insertRecord("Movies", new Movie 
            { 
                Title = "Justice League",
                Plot = "Fueled by his restored faith in humanity and inspired by Superman's selfless act, Bruce Wayne enlists the help of his new-found ally, Diana Prince, to face an even greater enemy.", 
                Fullplot = "Fueled by his restored faith in humanity and inspired by Superman's selfless act, Bruce Wayne enlists the help of his new-found ally, Diana Prince, to face an even greater enemy.",
                Directors = new List<string>() { "Zack Snyder" } ,
                Writers = new List<string>() { "Jerry Siegel (Superman created by)", "Joe Shuster (Superman created by)" }, 
                Lastupdated = DateTime.Now,Poster = "",
                Cast = new List<string>() { " Ben Affleck" , " Gal Gadot", "Jason Momoa" },
                Imdb = new Imdb() { Rating = 6.2, Votes = 39029 },
                Tomatoes = new Tomato() { 
                               Viewer = new TomatoViewer(){ NumReviews = 23, Rating= 4.5f }, 
                               Production = "test"}

            }
            );

            //  db.insertRecord("Courseposts", new Coursepost { Author="Test", Full_Desc="Book1", Title = "Book1", IsActive=1, Image = "bookjpg",EnteredDate = DateTime.Now });
            Console.WriteLine("Updated");

            //var recs = db.Get<Employee>("Employees");
            //foreach(var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id} : {rec.FirstName}  : {rec.Lastname} : {rec.Entereddate} ");
            //}

            //ar rec= db.GetById<Employee>("Employees", "21c10c57-64f3-4a05-ab94-f91c0340de15");

            //   var em = new Employee {Id= "ab7aa38e-757b-4d8d-b2e2-3c1dbb56d6db",FirstName="Neethu", EmailId = "neethu@gmail.com" };

            //  db.UpsertRecord("Employees", "ab7aa38e-757b-4d8d-b2e2-3c1dbb56d6db", em); 


            Console.Read();
        }
    }
}
