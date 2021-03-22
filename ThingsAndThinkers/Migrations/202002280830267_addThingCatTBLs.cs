namespace ThingsAndThinkers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addThingCatTBLs : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ThingID)
                .ForeignKey("dbo.AspNetUsers", t => t.ThinkerId, cascadeDelete: true)
                .Index(t => t.ThinkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThingCatTBLs", "ThinkerId", "dbo.AspNetUsers");
            DropIndex("dbo.ThingCatTBLs", new[] { "ThinkerId" });
            DropTable("dbo.ThingCatTBLs");
        }
    }
}
