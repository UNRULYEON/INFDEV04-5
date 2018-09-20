using System;
using System.Linq;
using Model;

namespace Lecture1
{
  class Program
  {
    static void Main(string[] args)
    {
			DataInsertion();
			Projection();
			Join();
    }

		static void DataInsertion()
		{
			using (var db = new MovieContext())
			{
				// Movie m = new Movie{
				// 	Title = "Divorce Italian Style",
				// 	Release = DateTime.Now,
				// 	Actors = new System.Collections.Generic.List<Actor> {
				// 		new Actor {
				// 			Name = "Marcello Mastroianni",
				// 			Birth = new DateTime(1988, 8, 29),
				// 			Gender = "Male"
				// 		},
				// 		new Actor {
				// 			Name = "Daniela Rocca",
				// 			Birth = new DateTime(1986, 5, 1),
				// 			Gender = "Female"
				// 		}
				// 	}
				// };

				// db.Add(m);
				// db.SaveChanges();
			}
		}

		static void Projection()
		{
			using (var db = new MovieContext())
			{
				// Projection
				// var projected_movies = from m in db.Movies select m;

				// Projection with filtering
				// var projected_movies =	from m in db.Movies
				// 												where m.Release > new DateTime(2000, 1, 1)
				// 												select m;

				// Projetion with ordering
				var projected_movies = 	from m in db.Movies
																where m.Release > new DateTime(2000, 1, 1)
																orderby m.Release descending
																select m;

				Console.WriteLine("Movie title | release");
				foreach (var movie in projected_movies)
				{
					Console.WriteLine("- {0} | {1}", movie.Title, movie.Release);
				}
			}
		}

		static void Join()
		{
			using (var db = new MovieContext())
			{

			}
		}
  }
}
