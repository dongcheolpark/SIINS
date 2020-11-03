namespace SiinsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClssNoti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassNotis", "ClassNotiEmergency", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassNotis", "ClassNotiEmergency");
        }
    }
}
