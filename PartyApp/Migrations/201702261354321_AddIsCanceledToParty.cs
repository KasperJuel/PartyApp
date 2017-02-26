namespace PartyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToParty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parties", "IsCanceled");
        }
    }
}
