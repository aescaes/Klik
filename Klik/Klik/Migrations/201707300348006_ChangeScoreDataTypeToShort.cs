namespace Klik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeScoreDataTypeToShort : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameSessions", "Score", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameSessions", "Score", c => c.Byte(nullable: false));
        }
    }
}
