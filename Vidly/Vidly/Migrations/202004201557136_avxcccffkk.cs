namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avxcccffkk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieNews", "Releasedate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MovieNews", "Dateadded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieNews", "Dateadded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MovieNews", "Releasedate", c => c.DateTime(nullable: false));
        }
    }
}
