namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Employee_VEmployeeId", "dbo.Employees");
            DropIndex("dbo.Clients", new[] { "Employee_VEmployeeId" });
            DropIndex("dbo.Houses", new[] { "Client_ClientId" });
            DropColumn("dbo.Clients", "Employee_VEmployeeId");
            DropColumn("dbo.Houses", "Client_ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Client_ClientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Clients", "Employee_VEmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Houses", "Client_ClientId");
            CreateIndex("dbo.Clients", "Employee_VEmployeeId");
            AddForeignKey("dbo.Clients", "Employee_VEmployeeId", "dbo.Employees", "VEmployeeId");
            AddForeignKey("dbo.Houses", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
