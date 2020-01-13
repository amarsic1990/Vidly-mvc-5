namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4, 'Thriler')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5, 'Horor')");
        }
        
        public override void Down()
        {
        }
    }
}
