namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclassnoti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassNotis",
                c => new
                    {
                        key = c.Int(nullable: false, identity: true),
                        ClassNotiText = c.String(),
                        ClassNotiAttribute = c.String(),
                        ClassNoticlass = c.String(),
                        ClassNotiTime = c.String(),
                    })
                .PrimaryKey(t => t.key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassNotis");
        }
    }
}
