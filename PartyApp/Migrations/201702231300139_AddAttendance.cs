namespace PartyApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                {
                    PartyId = c.Int(nullable: false),
                    AttendeeId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.PartyId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.PartyId)
                .Index(t => t.PartyId)
                .Index(t => t.AttendeeId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "PartyId" });
            DropTable("dbo.Attendances");
        }
    }
}
