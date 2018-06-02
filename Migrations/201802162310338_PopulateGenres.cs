namespace CourseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (id,name) VALUES (1,'Jazz')");
            Sql("INSERT INTO Genres (id,name) VALUES (2,'Blues')");
            Sql("INSERT INTO Genres (id,name) VALUES (3,'Rock')");
            Sql("INSERT INTO Genres (id,name) VALUES (4,'Country')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE id IN (1,2,3,4)");
        }
    }
}
