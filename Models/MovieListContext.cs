using MvcMovie.Models;
using System.Data.Entity;

namespace MvcMovie2.Models
{
    public class MovieListContext : DbContext
    {
        //public MovieListContext() : base("name=MovieListContext")
        public MovieListContext() : base("MovieListContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<LogIn> LogIn { get; set; }
    }
}