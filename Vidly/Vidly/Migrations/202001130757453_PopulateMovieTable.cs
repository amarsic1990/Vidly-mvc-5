namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Hangover', 'Comedy', '2015-01-01', '2017-01-01', 5)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Die Hard', 'Action', '2005-09-02', '2012-01-01', 15)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('The Terminator', 'Action', '2000-01-01', '2004-01-01', 2)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Titanic', 'Drama', '2015-01-01', '2017-01-01', 1)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES('Toy Story', 'Family', '2015-01-01', '2017-01-01', 3)");
        }
        
        public override void Down()
        {
        }
    }
}
