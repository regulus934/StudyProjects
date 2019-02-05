namespace WebApplication1.Migrations.InventoryDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Kolvo = c.Int(nullable: false),
                        Comments = c.String(),
                        RequestId_id = c.Int(),
                    })
                .PrimaryKey(t => t.InstrumentID)
                .ForeignKey("dbo.Requests", t => t.RequestId_id)
                .Index(t => t.RequestId_id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Month = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instruments", "RequestId_id", "dbo.Requests");
            DropIndex("dbo.Instruments", new[] { "RequestId_id" });
            DropTable("dbo.Requests");
            DropTable("dbo.Instruments");
        }
    }
}
