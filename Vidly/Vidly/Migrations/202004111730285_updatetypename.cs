namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetypename : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set MembershipTypeName='Pay as You Go' where Id=1");
            Sql("update MembershipTypes set MembershipTypeName='Monthly' where Id=2");
            Sql("update MembershipTypes set MembershipTypeName='Quartely' where Id=3");
            Sql("update MembershipTypes set MembershipTypeName='Annual' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
