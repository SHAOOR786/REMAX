namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "VPassword", c => c.String());
            AddColumn("dbo.Agents", "VPassword", c => c.String());
            AddColumn("dbo.Clients", "VPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "VPassword");
            DropColumn("dbo.Agents", "VPassword");
            DropColumn("dbo.Admins", "VPassword");
        }
    }
}
