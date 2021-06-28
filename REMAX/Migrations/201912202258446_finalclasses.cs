namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalclasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "VRefEmp", c => c.String());
            AddColumn("dbo.Houses", "VRefClient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Houses", "VRefClient");
            DropColumn("dbo.Clients", "VRefEmp");
        }
    }
}
