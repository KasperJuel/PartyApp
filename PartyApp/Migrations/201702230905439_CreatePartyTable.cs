namespace PartyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePartyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 250),
                        PartyType_Id = c.Byte(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartyTypes", t => t.PartyType_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.PartyType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PartyTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parties", "PartyType_Id", "dbo.PartyTypes");
            DropIndex("dbo.Parties", new[] { "User_Id" });
            DropIndex("dbo.Parties", new[] { "PartyType_Id" });
            DropTable("dbo.PartyTypes");
            DropTable("dbo.Parties");
        }
    }
}
