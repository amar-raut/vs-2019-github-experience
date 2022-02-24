namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rcustomerbirthdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "CustomerBirthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerBirthdate", c => c.DateTime(nullable: false));
        }
    }
}
