namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattributetomovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AddColumn("dbo.Movies", "Releasedate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Dateadded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Noofstock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Noofstock");
            DropColumn("dbo.Movies", "Dateadded");
            DropColumn("dbo.Movies", "Releasedate");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
