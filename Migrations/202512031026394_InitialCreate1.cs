namespace MvcMovie2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogIns", "CreateAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LogIns", "UpdateAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogIns", "UpdateAt", c => c.String());
            AlterColumn("dbo.LogIns", "CreateAt", c => c.String());
        }
    }
}
