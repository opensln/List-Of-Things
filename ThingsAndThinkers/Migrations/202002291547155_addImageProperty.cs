namespace ThingsAndThinkers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThingTBLs", "ThingImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThingTBLs", "ThingImage");
        }
    }
}
