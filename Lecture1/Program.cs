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
				// var projected_movies = 	from m in db.Movies
				// 												where m.Release > new DateTime(2000, 1, 1)
				// 												orderby m.Release descending
				// 												select m;

				// Grouping
				// var projected_movies = 	from a in db.Actors
				// 												group a by a.Gender into genderGroup
				// 												select genderGroup;

				// Aggregation
				// var result = 	from movie in db.Movies
				// 							from actor in db.Actors
				// 								where actor.MovieId == movie.Id
				// 								group actor by actor.Gender into GenderGrp
				// 							select Tuple.Create (
				// 								GenderGrp.Key,
				// 								GenderGrp.Count()
				// 							);

				// Joining
				// var projected_movies = 	from movie in db.Movies
				// 												from actor in db.Actors
				// 												where movie.Id == actor.Id
				// 												select new {
				// 													Title = movie.Title,
				// 													actorName = actor.Name
				// 												};

				// Subquery and aggregation
				var projected_movies = 	from movie in db.Movies
																let actors_of_movie = (
																	from actor in db.Actors
																	where actor.MovieId == movie.Id
																	select actor
																)
																where actors_of_movie.Count() < 3
																select new {
																	Title = movie.Title,
																	ActorsCount = actors_of_movie.Count()
																};


				// Write movies
				// Console.WriteLine("Movie title | release");
				// foreach (var movie in projected_movies)
				// {
				// 	Console.WriteLine("- {0} | {1}", movie.Title, movie.Release);
				// }

				// Write actors (grouping)
				// foreach (var movie in projected_movies){
				// 		Console.WriteLine("+ {0} ", movie.Key);
				// 		foreach (var actor in movie){
				// 				Console.WriteLine("-- {0} ", actor.Name);
				// 		}
				// }

				// Write actors (aggregation)
				// Console.WriteLine("Gender | Number of actors");
				// foreach (var item in result){
				// 					Console.WriteLine("{0} | {1}", item.Item1, item.Item2);
				// }

				// Write joining
				// Console.WriteLine("Movie | Actor");
				// foreach (var item in projected_movies){
				// 					Console.WriteLine("{0} | {1}", item.Title, item.actorName);
				// }

				// Write subquery and aggregation
				Console.WriteLine("Movie | Actor count");
				foreach (var item in projected_movies){
									Console.WriteLine("{0} | {1}", item.Title, item.ActorsCount);
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
