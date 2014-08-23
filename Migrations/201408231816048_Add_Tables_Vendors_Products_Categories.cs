namespace FBPortal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Tables_Vendors_Products_Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 50),
                        Description = c.String(),
                        Brand = c.String(maxLength: 256),
                        Quantity = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageTypeCode = c.Int(nullable: false),
                        PackageType = c.String(maxLength: 8),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                       DateAdded =c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                        Category_ID = c.Int(),
                        Vendor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Vendors", t => t.Vendor_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Description = c.String(),
                        DateAdded =c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Vendor_ID", "dbo.Vendors");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Vendor_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
