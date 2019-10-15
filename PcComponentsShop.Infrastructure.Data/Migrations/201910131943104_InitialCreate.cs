namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerCases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CaseType = c.String(nullable: false),
                        FormFactor = c.String(nullable: false),
                        PowerSupply = c.String(nullable: false),
                        Features = c.String(nullable: false),
                        MaxCpuCoolerHeight = c.Int(nullable: false),
                        MaxVideoCardLength = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemoryModules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemoryCapacity = c.Int(nullable: false),
                        MemoryType = c.String(nullable: false),
                        OperatingFrequency = c.Int(nullable: false),
                        OperatingVoltage = c.Single(nullable: false),
                        Timings = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Socket = c.String(nullable: false),
                        Chipset = c.String(nullable: false),
                        MemorySlots = c.String(nullable: false),
                        FormFactor = c.String(nullable: false),
                        VideoInterfaces = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PowerSupplies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FormFactor = c.String(nullable: false),
                        Power = c.Int(nullable: false),
                        Certification = c.String(nullable: false),
                        Cooling = c.String(nullable: false),
                        Features = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Microarchitecture = c.String(nullable: false),
                        Kernel = c.String(nullable: false),
                        Socket = c.String(nullable: false),
                        Frequency = c.Single(nullable: false),
                        CoreAmount = c.Int(nullable: false),
                        GraphicsCore = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SSDDrives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CellMemoryType = c.String(nullable: false),
                        Capacity = c.String(nullable: false),
                        FormFactor = c.String(nullable: false),
                        ConnectionInterface = c.String(nullable: false),
                        ReadingSpeed = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VideoCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Interface = c.String(nullable: false),
                        CoreFrequency = c.Int(nullable: false),
                        CoreFrequencyBoost = c.Int(nullable: false),
                        MemoryFrequency = c.Int(nullable: false),
                        Connectors = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideoCards");
            DropTable("dbo.SSDDrives");
            DropTable("dbo.Processors");
            DropTable("dbo.PowerSupplies");
            DropTable("dbo.Motherboards");
            DropTable("dbo.MemoryModules");
            DropTable("dbo.ComputerCases");
        }
    }
}
