namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filldatagenre : DbMigration
    {
        public override void Up()
        {
            Sql("delete from Genres where Id=3");
            Sql("insert into Genres(Genre_name) values ('Sci_Fi') ");
            Sql("insert into Genres(Genre_name) values ('Animation') ");
            Sql("insert into Genres(Genre_name) values ('Anime') ");
            Sql("insert into Genres(Genre_name) values ('Adventure') ");
            Sql("insert into Genres(Genre_name) values ('Drama') ");

           
        }
        
        public override void Down()
        {
        }
    }
}
