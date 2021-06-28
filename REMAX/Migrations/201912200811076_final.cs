namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Agent_AgentId", "dbo.Agents");
            DropIndex("dbo.Clients", new[] { "Agent_AgentId" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        VEmployeeId = c.String(nullable: false, maxLength: 128),
                        VFName = c.String(),
                        VLName = c.String(),
                        VEmail = c.String(),
                        VPhone = c.String(),
                        VPassword = c.String(),
                        VType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VEmployeeId);
            
            DropColumn("dbo.Clients", "Agent_AgentId");
            DropTable("dbo.Admins");
            DropTable("dbo.Agents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.String(nullable: false, maxLength: 128),
                        VFName = c.String(),
                        VLName = c.String(),
                        VEmail = c.String(),
                        VPhone = c.String(),
                        VPassword = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        VAdminId = c.String(nullable: false, maxLength: 128),
                        VFName = c.String(),
                        VLName = c.String(),
                        VEmail = c.String(),
                        VPhone = c.String(),
                        VPassword = c.String(),
                    })
                .PrimaryKey(t => t.VAdminId);
            
            AddColumn("dbo.Clients", "Agent_AgentId", c => c.String(maxLength: 128));
            DropTable("dbo.Employees");
            CreateIndex("dbo.Clients", "Agent_AgentId");
            AddForeignKey("dbo.Clients", "Agent_AgentId", "dbo.Agents", "AgentId");
        }
    }
}
