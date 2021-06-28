namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Employee_VEmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Clients", "Employee_VEmployeeId");
            AddForeignKey("dbo.Clients", "Employee_VEmployeeId", "dbo.Employees", "VEmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Employee_VEmployeeId", "dbo.Employees");
            DropIndex("dbo.Clients", new[] { "Employee_VEmployeeId" });
            DropColumn("dbo.Clients", "Employee_VEmployeeId");
        }
    }
}
