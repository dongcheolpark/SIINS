namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedCategories",
                c => new
                    {
                        CatUId = c.Int(nullable: false, identity: true),
                        CatUName = c.Int(nullable: false),
                        CatUSelect = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CatUId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                        CatAttribute = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
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
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentNo = c.Int(nullable: false, identity: true),
                        ParentNo = c.Int(nullable: false),
                        CommentContents = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.CommentNo);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        NoteNo = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        T_Name = c.String(),
                        Contents = c.String(),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        NoteGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteNo);
            
            CreateTable(
                "dbo.NoteCats",
                c => new
                    {
                        NoteCatId = c.Int(nullable: false, identity: true),
                        NoteNo = c.Int(nullable: false),
                        CatAttribute = c.String(),
                    })
                .PrimaryKey(t => t.NoteCatId);
            
            CreateTable(
                "dbo.NoteClasses",
                c => new
                    {
                        NoteClassId = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        NoteClasses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteClassId);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.NoteClasses");
            DropTable("dbo.NoteCats");
            DropTable("dbo.Homework");
            DropTable("dbo.Comments");
            DropTable("dbo.ClassNotis");
            DropTable("dbo.Categories");
            DropTable("dbo.SelectedCategories");
        }
    }
}
