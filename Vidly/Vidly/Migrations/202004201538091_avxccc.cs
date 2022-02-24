namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avxccc : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "MovieNews");
            RenameColumn(table: "dbo.MovieNews", name: "GenreTypeId", newName: "GenreId");
            RenameIndex(table: "dbo.MovieNews", name: "IX_GenreTypeId", newName: "IX_GenreId");
            CreateTable(
                "dbo.GenreNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //AlterColumn("dbo.MovieNews", "Releasedate", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.MovieNews", "Dateadded", c => c.DateTime(nullable: false));

            Sql("ALTER TABLE dbo.MovieNews ALTER COLUMN Releasedate datetime2;");
            Sql("ALTER TABLE dbo.MovieNews ALTER COLUMN Dateadded datetime2;");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieNews", "Dateadded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MovieNews", "Releasedate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropTable("dbo.GenreNews");
            RenameIndex(table: "dbo.MovieNews", name: "IX_GenreId", newName: "IX_GenreTypeId");
            RenameColumn(table: "dbo.MovieNews", name: "GenreId", newName: "GenreTypeId");
            RenameTable(name: "dbo.MovieNews", newName: "Movies");
        }
    }
}
