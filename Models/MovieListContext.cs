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
        //public DbSet<Board> Boards { get; set; }
        // ★★★ 이 줄을 추가하세요! (Board 테이블 등록) ★★★
        public DbSet<Board> Board { get; set; }
    }
}