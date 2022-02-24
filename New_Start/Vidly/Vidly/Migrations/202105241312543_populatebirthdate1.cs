namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatebirthdate1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET CustomerBirthdate = '1996-03-16 00:00:00.000' WHERE ID = 17");
        }
        
        public override void Down()
        {
        }
    }
}
