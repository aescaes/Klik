namespace Klik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDifficulties : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Difficulties (Id, Name) VALUES (1, 'Easy')");
            Sql("INSERT INTO Difficulties (Id, Name) VALUES (2, 'Medium')");
            Sql("INSERT INTO Difficulties (Id, Name) VALUES (3, 'Hard')");
        }
        
        public override void Down()
        {
        }
    }
}
