namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "VHouseType", c => c.Int(nullable: false));
            DropColumn("dbo.Houses", "HouseType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "HouseType", c => c.String());
            DropColumn("dbo.Houses", "VHouseType");
        }
    }
}
