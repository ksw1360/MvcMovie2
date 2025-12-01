using MvcMovie.Models;
using System.Data.Entity;

namespace MvcMovie2.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext() : base("name=MovieListContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}