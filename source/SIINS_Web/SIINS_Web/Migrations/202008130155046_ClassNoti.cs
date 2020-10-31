namespace testweb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassNoti : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VotesDatas");
            DropTable("dbo.VotesInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VotesInfoes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        VoteName = c.String(),
                        ChoiceCounts = c.Int(nullable: false),
                        ChoiceOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId);
            
            CreateTable(
                "dbo.VotesDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoteId = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                        ChoiceSen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
