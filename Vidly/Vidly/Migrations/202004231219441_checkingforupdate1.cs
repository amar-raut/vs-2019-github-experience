namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkingforupdate1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GenreNews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
