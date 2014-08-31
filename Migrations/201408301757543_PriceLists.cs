namespace FBPortal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceLists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        File = c.Binary(),
                        FilePath = c.String(),
                        Client_ClientId = c.Guid(),
                        Vendor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .ForeignKey("dbo.Vendors", t => t.Vendor_ID)
                .Index(t => t.Client_ClientId)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.PriceListData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductNumber = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(nullable: false),
                        PriceList_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PriceLists", t => t.PriceList_ID)
                .Index(t => t.PriceList_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceLists", "Vendor_ID", "dbo.Vendors");
            DropForeignKey("dbo.PriceListData", "PriceList_ID", "dbo.PriceLists");
            DropForeignKey("dbo.PriceLists", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.PriceListData", new[] { "PriceList_ID" });
            DropIndex("dbo.PriceLists", new[] { "Vendor_ID" });
            DropIndex("dbo.PriceLists", new[] { "Client_ClientId" });
            DropTable("dbo.PriceListData");
            DropTable("dbo.PriceLists");
        }
    }
}
