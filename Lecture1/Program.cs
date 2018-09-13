using System;
using Model;

namespace Lecture1
{
  class Program
  {
    static void Main(string[] args)
    {
			using (var db = new MovieContext())
			{

				// Movie m = new Movie
				// {
				// 	Title = "No country for old men",
				// 	Actors = new System.Collections.Generic.List<Actor> {
				// 		new Actor{Name = "Tommy Lee"},
				// 		new Actor{Name = "Xavier Berdem"}
				// 	}
				// };
				// db.Movies.Add(m);
				// db.SaveChanges();

				// Movie foundMovie = db.Movies.Find(1);
				// Console.WriteLine("Found movie with title" + foundMovie.Title);
				// foundMovie.Title = "White cats, Black cats...";
				// db.SaveChanges();
				// Console.WriteLine("Title changed");
			}

      Console.WriteLine("Hello World!");
    }
  }
}
