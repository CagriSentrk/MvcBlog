﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Title", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "Mail", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "PhoneNumber");
            DropColumn("dbo.Authors", "Mail");
            DropColumn("dbo.Authors", "Title");
        }
    }
}
