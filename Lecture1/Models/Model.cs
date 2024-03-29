using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Model
{
  public class MovieContext : DbContext
  {
    //this is actual entity object linked to the movies in our DB
    public DbSet<Movie> Movies { get; set; }
    //this is actual entity object linked to the actors in our DB
    public DbSet<Actor> Actors { get; set; }

    //this method is run automatically by EF the first time we run the application
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //here we define the name of our database
      optionsBuilder.UseNpgsql("User ID=postgres;Password=;Host=localhost;Port=5432;Database=MovieDB;Pooling=true;");

      //activate logging for compiled queries
      var lf = new LoggerFactory();
      lf.AddProvider(new MyLoggerProvider());
      optionsBuilder.UseLoggerFactory(lf);
    }

  }

  //this is the typed representation of a movie in our project
  public class Movie
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Release { get; set; }
    public List<Actor> Actors { get; set; }
  }

  //this is the typed representation of an actor in our project
  public class Actor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string Gender { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
  }
}