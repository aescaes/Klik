namespace Klik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDifficultyToGameSession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GameSessions", "DifficultyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.GameSessions", "DifficultyId");
            AddForeignKey("dbo.GameSessions", "DifficultyId", "dbo.Difficulties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameSessions", "DifficultyId", "dbo.Difficulties");
            DropIndex("dbo.GameSessions", new[] { "DifficultyId" });
            DropColumn("dbo.GameSessions", "DifficultyId");
            DropTable("dbo.Difficulties");
        }
    }
}
