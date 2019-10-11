using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PcComponentsShop.Domain.Core.Basic_Models;

namespace PcComponentsShop.Infrastructure.Data.Contexts
{
    public class PcComponentsContext : DbContext
    {
        public DbSet<ComputerCase> ComputerCases { get; set; }
        public DbSet<MemoryModule> MemoryModules { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSuppliess { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<SSDDrive> SSDDrives { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
    }
    public class ComponentsInitializer : DropCreateDatabaseAlways<PcComponentsContext>
    {
        protected override void Seed(PcComponentsContext context)
        {
            context.ComputerCases.Add(new ComputerCase() { Brand = "Gamemax", CaseType = "Midi Tower", Category = "Computer Case", Features = "SO BIG BLYAT", FormFactor = "ATX", FullName = "Super sasniy corpus XD", ImgSrc = "mock.com", MaxCpuCoolerHeight = 162, MaxVideoCardLength = 328, PowerSupply = false, Price = 1288 });
            context.MemoryModules.Add(new MemoryModule() { Brand = "Samsung", Category = "Memory modules", FullName = "Samsung mega memory", ImgSrc = "mock.com", MemoryCapacity = 16, MemoryType = "DDR4", OperatingFrequency = 2333, OperatingVoltage = 1.48f, Price = 2300, Timings = "Cl17" });
        }
    }
}
