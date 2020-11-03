namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class co1 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
        }
    }
}
