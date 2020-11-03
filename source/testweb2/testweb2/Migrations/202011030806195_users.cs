namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserNo = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserClass = c.String(),
                        UserId = c.String(),
                        UserPassword = c.String(),
                        UserGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserNo);
            
            DropTable("dbo.NoteClasses");
        }
        
        public override void Down()
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
            
            DropTable("dbo.Users");
        }
    }
}
