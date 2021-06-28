namespace REMAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRemax : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        VAdminId = c.String(nullable: false, maxLength: 128),
                        VFName = c.String(),
                        VLName = c.String(),
                        VEmail = c.String(),
                        VPhone = c.String(),
                    })
                .PrimaryKey(t => t.VAdminId);

            CreateTable(
                "dbo.Agents",
                c => new
                {
                    AgentId = c.String(nullable: false, maxLength: 128),
                    VFName = c.String(),
                    VLName = c.String(),
                    VEmail = c.String(),
                    VPhone = c.String(),

                })
                .PrimaryKey(t => t.AgentId);



            CreateTable(
                "dbo.Clients",
                c => new
                {
                    ClientId = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    PhoneNumber = c.String(),

                })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        HouseNumber = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        HouseType = c.String(),
                        Client_ClientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HouseNumber)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Admin_VAdminId", "dbo.Admins");
            DropForeignKey("dbo.Agents", "Admin_VAdminId", "dbo.Admins");
            DropForeignKey("dbo.Clients", "Agent_AgentId", "dbo.Agents");
            DropForeignKey("dbo.Houses", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Houses", new[] { "Client_ClientId" });
            DropIndex("dbo.Clients", new[] { "Admin_VAdminId" });
            DropIndex("dbo.Clients", new[] { "Agent_AgentId" });
            DropIndex("dbo.Agents", new[] { "Admin_VAdminId" });
            DropTable("dbo.Houses");
            DropTable("dbo.Clients");
            DropTable("dbo.Agents");
            DropTable("dbo.Admins");
        }
    }
}
