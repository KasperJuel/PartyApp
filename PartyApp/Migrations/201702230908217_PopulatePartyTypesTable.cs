namespace PartyApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatePartyTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (1, 'Privat Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (2, 'Tema Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (3, 'Vej Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (4, 'Nytårs Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (5, 'Halloween Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (6, 'Grill Fest')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (7, 'Julefrokost')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (8, 'Påskefrokost')");
            Sql("INSERT INTO PartyTypes (Id, Name) VALUES (9, 'Koncert')");
        }

        public override void Down()
        {
            Sql("DELETE FROM PartyTypes WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9");
        }
    }
}
