namespace MvcMovie2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        NickName = c.String(),
                        CreateAt = c.String(),
                        UpdateAt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Genre = c.String(maxLength: 255),
                        Director = c.String(maxLength: 255),
                        LeadActor = c.String(maxLength: 255),
                        Size = c.Long(),
                        Year = c.Int(),
                        ReleaseDate = c.DateTime(),
                        Runtime = c.Int(),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        Plot = c.String(),
                        Country = c.String(maxLength: 100),
                        Language = c.String(maxLength: 100),
                        PosterURL = c.String(maxLength: 500),
                        Budget = c.Long(),
                        Revenue = c.Long(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movie");
            DropTable("dbo.LogIns");
        }
    }
}
