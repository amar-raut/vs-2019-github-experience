namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Releasedate =c.DateTime(),
                    Dateadded =c.DateTime(),
                    Noofstock = c.Int(),

                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movies", "GenreId", c => c.Int());
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");
        }


        public override void Down()
        {
        }
    }
}
