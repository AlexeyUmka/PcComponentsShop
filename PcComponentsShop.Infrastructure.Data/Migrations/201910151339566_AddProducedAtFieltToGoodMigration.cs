namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProducedAtFieltToGoodMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComputerCases", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.MemoryModules", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Motherboards", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.PowerSupplies", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Processors", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.SSDDrives", "ProducedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.VideoCards", "ProducedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoCards", "ProducedAt");
            DropColumn("dbo.SSDDrives", "ProducedAt");
            DropColumn("dbo.Processors", "ProducedAt");
            DropColumn("dbo.PowerSupplies", "ProducedAt");
            DropColumn("dbo.Motherboards", "ProducedAt");
            DropColumn("dbo.MemoryModules", "ProducedAt");
            DropColumn("dbo.ComputerCases", "ProducedAt");
        }
    }
}
