namespace ThingsAndThinkers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBuildForNewSiteThoughtNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ThingCatTBLs", "ThinkerId", "dbo.AspNetUsers");
            DropIndex("dbo.ThingCatTBLs", new[] { "ThinkerId" });
            CreateTable(
                "dbo.ThingCategoryTBLs",
                c => new
                    {
                        ThingCatID = c.Int(nullable: false, identity: true),
                        ThingCatName = c.String(nullable: false),
                        ThingCatIcon = c.String(),
                    })
                .PrimaryKey(t => t.ThingCatID);
            
            CreateTable(
                "dbo.ThingTBLs",
                c => new
                    {
                        ThingID = c.Int(nullable: false, identity: true),
                        ThinkerId = c.String(nullable: false, maxLength: 128),
                        ThingName = c.String(nullable: false),
                        ThingCatThingCatID = c.Int(nullable: false),
                        ThoughtName = c.String(),
                    })
                .PrimaryKey(t => t.ThingID)
                .ForeignKey("dbo.ThingCategoryTBLs", t => t.ThingCatThingCatID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ThinkerId, cascadeDelete: true)
                .Index(t => t.ThinkerId)
                .Index(t => t.ThingCatThingCatID);
            
            DropTable("dbo.ThingCatTBLs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ThingCatTBLs",
                c => new
                    {
                        ThingID = c.Int(nullable: false, identity: true),
                        ThinkerId = c.String(nullable: false, maxLength: 128),
                        ThingCategoryName = c.String(nullable: false),
                        ThingCategoryIcon = c.String(),
                    })
                .PrimaryKey(t => t.ThingID);
            
            DropForeignKey("dbo.ThingTBLs", "ThinkerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ThingTBLs", "ThingCatThingCatID", "dbo.ThingCategoryTBLs");
            DropIndex("dbo.ThingTBLs", new[] { "ThingCatThingCatID" });
            DropIndex("dbo.ThingTBLs", new[] { "ThinkerId" });
            DropTable("dbo.ThingTBLs");
            DropTable("dbo.ThingCategoryTBLs");
            CreateIndex("dbo.ThingCatTBLs", "ThinkerId");
            AddForeignKey("dbo.ThingCatTBLs", "ThinkerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
