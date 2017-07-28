namespace Klik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameSession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Score = c.Byte(nullable: false),
                        DatePlayed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameSessions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.GameSessions", new[] { "UserId" });
            DropTable("dbo.GameSessions");
        }
    }
}
