namespace MvcMovie2.Migrations
{
    using MvcMovie.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie2.Models.MovieListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcMovie.Models.MovieListContext";
        }

        protected override void Seed(MvcMovie2.Models.MovieListContext context)
        {
            // 기존 테이블 강제 삭제 (충돌 해결!!!)
            context.Database.ExecuteSqlCommand("IF OBJECT_ID('dbo.LogIns', 'U') IS NOT NULL DROP TABLE dbo.LogIns;");
            context.Database.ExecuteSqlCommand("IF OBJECT_ID('dbo.Movies', 'U') IS NOT NULL DROP TABLE dbo.Movies;");

            // 여기 아래는 너가 원래 있던 코드 그대로 두기
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "인셉션", Genre = "SF" },//, Price = 19.99m },
                new Movie { Title = "덤앤더머", Genre = "코미디" }//, Price = 15.99m }
            );

            // 필요하면 LogIn 테이블에 테스트 계정도 넣기
            context.LogIns.AddOrUpdate(
                u => u.Id,
                new LogIn { Id = "admin", Password = "1234", NickName = "김상우" }
            );
        }
    }
}
