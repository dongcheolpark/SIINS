namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noteclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteClasses",
                c => new
                    {
                        NoteClassId = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        NoteClasses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteClassId);
            
            DropTable("dbo.Grades");
        }
        
        public override void Down()
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
            
            DropTable("dbo.NoteClasses");
        }
    }
}
