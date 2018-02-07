namespace TfrRedo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ArrivalDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instruction_Summary = c.String(),
                        Instruction_Detailed = c.String(),
                        Duration = c.Int(nullable: false),
                        DurationHours = c.Int(nullable: false),
                        DurationMinutes = c.Int(nullable: false),
                        Distance = c.Single(nullable: false),
                        Journey_Id = c.Int(),
                        Journey_Id1 = c.Int(),
                        Journey_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journeys", t => t.Journey_Id)
                .ForeignKey("dbo.Journeys", t => t.Journey_Id1)
                .ForeignKey("dbo.Journeys", t => t.Journey_Id2)
                .Index(t => t.Journey_Id)
                .Index(t => t.Journey_Id1)
                .Index(t => t.Journey_Id2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "Journey_Id2", "dbo.Journeys");
            DropForeignKey("dbo.Legs", "Journey_Id1", "dbo.Journeys");
            DropForeignKey("dbo.Legs", "Journey_Id", "dbo.Journeys");
            DropIndex("dbo.Legs", new[] { "Journey_Id2" });
            DropIndex("dbo.Legs", new[] { "Journey_Id1" });
            DropIndex("dbo.Legs", new[] { "Journey_Id" });
            DropTable("dbo.Legs");
            DropTable("dbo.Journeys");
        }
    }
}
