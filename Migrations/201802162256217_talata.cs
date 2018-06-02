namespace CourseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_id" });
            AlterColumn("dbo.Gigs", "Genre_id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "Genre_id");
            AddForeignKey("dbo.Gigs", "Genre_id", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_id" });
            AlterColumn("dbo.Gigs", "Genre_id", c => c.Byte());
            CreateIndex("dbo.Gigs", "Genre_id");
            AddForeignKey("dbo.Gigs", "Genre_id", "dbo.Genres", "id");
        }
    }
}
