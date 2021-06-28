namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCode : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agents", "Admin_VAdminId", "dbo.Admins");
            DropForeignKey("dbo.Clients", "Admin_VAdminId", "dbo.Admins");
            DropIndex("dbo.Agents", new[] { "Admin_VAdminId" });
            DropIndex("dbo.Clients", new[] { "Admin_VAdminId" });
            DropColumn("dbo.Agents", "Admin_VAdminId");
            DropColumn("dbo.Clients", "Admin_VAdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Admin_VAdminId", c => c.String(maxLength: 128));
            AddColumn("dbo.Agents", "Admin_VAdminId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Clients", "Admin_VAdminId");
            CreateIndex("dbo.Agents", "Admin_VAdminId");
            AddForeignKey("dbo.Clients", "Admin_VAdminId", "dbo.Admins", "VAdminId");
            AddForeignKey("dbo.Agents", "Admin_VAdminId", "dbo.Admins", "VAdminId");
        }
    }
}
