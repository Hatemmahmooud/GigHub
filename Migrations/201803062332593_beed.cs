namespace CourseProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FolloweeID = c.String(nullable: false, maxLength: 128),
                        FollowerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FolloweeID, t.FollowerID })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerID)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeID)
                .Index(t => t.FolloweeID)
                .Index(t => t.FollowerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerID", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FollowerID" });
            DropIndex("dbo.Followings", new[] { "FolloweeID" });
            DropTable("dbo.Followings");
        }
    }
}
