using System.Data.Entity.Migrations;

namespace TfrRedo.DataAccess.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Journeys",
                    c => new
                    {
                        Id = c.Int(false, true),
                        StartDateTime = c.DateTime(false),
                        Duration = c.Int(false),
                        ArrivalDateTime = c.DateTime(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Legs",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Instruction_Summary = c.String(),
                        Instruction_Detailed = c.String(),
                        Duration = c.Int(false),
                        DurationHours = c.Int(false),
                        DurationMinutes = c.Int(false),
                        Distance = c.Single(false),
                        Journey_Id = c.Int(),
                        Journey_Id1 = c.Int(),
                        Journey_Id2 = c.Int()
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
            DropIndex("dbo.Legs", new[] {"Journey_Id2"});
            DropIndex("dbo.Legs", new[] {"Journey_Id1"});
            DropIndex("dbo.Legs", new[] {"Journey_Id"});
            DropTable("dbo.Legs");
            DropTable("dbo.Journeys");
        }
    }
}