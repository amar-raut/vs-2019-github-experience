namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolumntype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "Dateadded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Dateadded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTime(nullable: false));
        }
    }
}
