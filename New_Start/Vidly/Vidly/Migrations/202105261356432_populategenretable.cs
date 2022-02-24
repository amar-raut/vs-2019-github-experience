namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenretable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Name) values('Action')");
            Sql("Insert into Genres (Name) values('Comedy')");
            Sql("Insert into Genres (Name) values('Anime')");
            Sql("Insert into Genres (Name) values('Animation')");
            Sql("Insert into Genres (Name) values('Horror')");
            Sql("Insert into Genres (Name) values('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
