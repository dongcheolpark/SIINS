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
        }
        
        public override void Down()
        {
        }
    }
}
