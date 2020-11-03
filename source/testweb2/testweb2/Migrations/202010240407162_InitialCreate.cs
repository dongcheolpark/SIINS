namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeNo = c.Int(nullable: false, identity: true),
                        Class1 = c.Int(nullable: false),
                        Class2 = c.Int(nullable: false),
                        Class3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeNo);
            
            DropTable("dbo.ClassNotis");
        }
        
        public override void Down()
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
                        ClassNotiEmergency = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.key);
            
            DropTable("dbo.Grades");
        }
    }
}
