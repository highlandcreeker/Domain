namespace FBPortal.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rev_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Balance");
        }
    }
}
