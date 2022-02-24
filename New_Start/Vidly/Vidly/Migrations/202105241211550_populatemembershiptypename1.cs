﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershiptypename1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Membershiptypes SET MembershipTypeName = 'Pay As You Go' WHERE ID = 1");
            Sql("UPDATE Membershiptypes SET MembershipTypeName = 'Monthly' WHERE ID = 2");
            Sql("UPDATE Membershiptypes SET MembershipTypeName = 'Quarterly' WHERE ID = 3");
            Sql("UPDATE Membershiptypes SET MembershipTypeName = 'Annual' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
