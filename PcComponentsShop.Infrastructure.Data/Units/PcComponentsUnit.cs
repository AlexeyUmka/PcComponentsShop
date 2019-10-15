using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcComponentsShop.Infrastructure.Data.Contexts;
using PcComponentsShop.Infrastructure.Data.Repositories;

namespace PcComponentsShop.Infrastructure.Data.Units
{
    public class PcComponentsUnit : IDisposable
    {
        private PcComponentsShopContext db = new PcComponentsShopContext();
        private ComputerСaseRepository computerСaseRepository;
        private MemoryModuleRepository memoryModuleRepository;
        private MotherboardRepository motherboardRepository;
        private PowerSupplyRepository powerSupplyRepository;
        private ProcessorRepository processorRepository;
        private SSDDriveRepository sSDDriveRepository;
        private VideoCardRepository videoCardRepository;
        
        public ComputerСaseRepository ComputerСases
        {
            get
            {
                if (computerСaseRepository == null)
                    computerСaseRepository = new ComputerСaseRepository(db, db.ComputerCases);
                return computerСaseRepository;
            }
        }
        public MemoryModuleRepository MemoryModules
        {
            get
            {
                if (memoryModuleRepository == null)
                    memoryModuleRepository = new MemoryModuleRepository(db, db.MemoryModules);
                return memoryModuleRepository;
            }
        }
        public MotherboardRepository Motherboards
        {
            get
            {
                if (motherboardRepository == null)
                    motherboardRepository = new MotherboardRepository(db, db.Motherboards);
                return motherboardRepository;
            }
        }
        public PowerSupplyRepository PowerSupplies
        {
            get
            {
                if (powerSupplyRepository == null)
                    powerSupplyRepository = new PowerSupplyRepository(db, db.PowerSuppliess);
                return powerSupplyRepository;
            }
        }
        public ProcessorRepository Processors
        {
            get
            {
                if (processorRepository == null)
                    processorRepository = new ProcessorRepository(db, db.Processors);
                return processorRepository;
            }
        }
        public SSDDriveRepository SSDDrives
        {
            get
            {
                if (sSDDriveRepository == null)
                    sSDDriveRepository = new SSDDriveRepository(db, db.SSDDrives);
                return sSDDriveRepository;
            }
        }
        public VideoCardRepository VideoCards
        {
            get
            {
                if (videoCardRepository == null)
                    videoCardRepository = new VideoCardRepository(db, db.VideoCards);
                return videoCardRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
