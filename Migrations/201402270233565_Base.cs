namespace FBPortal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckId = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 50),
                        Paid = c.Boolean(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CheckId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Guid(nullable: false),
                        Name = c.String(),
                        Vendor = c.String(),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.ClientPeriods",
                c => new
                    {
                        ClientPeriodId = c.Guid(nullable: false),
                        TotalExpense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeriodId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ClientPeriodId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Periods", t => t.PeriodId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PeriodId);
            
            CreateTable(
                "dbo.Periods",
                c => new
                    {
                        PeriodId = c.Guid(nullable: false),
                        Rank = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Guid(nullable: false),
                        CostofGoodsSold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalariesAndWages = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DirectOperating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Marketing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Utilities = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Occupancy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Maintenance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Administrative = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CorporateOverhead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeriodId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Periods", t => t.PeriodId, cascadeDelete: true)
                .Index(t => t.PeriodId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ClientId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Checks", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientPeriods", "PeriodId", "dbo.Periods");
            DropForeignKey("dbo.Expenses", "PeriodId", "dbo.Periods");
            DropForeignKey("dbo.ClientPeriods", "ClientId", "dbo.Clients");
            DropIndex("dbo.AspNetUsers", new[] { "ClientId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Checks", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.ClientPeriods", new[] { "PeriodId" });
            DropIndex("dbo.Expenses", new[] { "PeriodId" });
            DropIndex("dbo.ClientPeriods", new[] { "ClientId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Expenses");
            DropTable("dbo.Periods");
            DropTable("dbo.ClientPeriods");
            DropTable("dbo.Clients");
            DropTable("dbo.Invoices");
            DropTable("dbo.Checks");
        }
    }
}
