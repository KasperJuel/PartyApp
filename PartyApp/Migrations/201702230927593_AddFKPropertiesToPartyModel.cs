namespace PartyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKPropertiesToPartyModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Parties", name: "PartyType_Id", newName: "PartyTypeId");
            RenameColumn(table: "dbo.Parties", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Parties", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Parties", name: "IX_PartyType_Id", newName: "IX_PartyTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Parties", name: "IX_PartyTypeId", newName: "IX_PartyType_Id");
            RenameIndex(table: "dbo.Parties", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Parties", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Parties", name: "PartyTypeId", newName: "PartyType_Id");
        }
    }
}
