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
        private PcComponentsContext db = new PcComponentsContext();
        private ComputerСaseRepository computerСaseRepository;
        private MemoryModuleRepository memoryModuleRepository;
        
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
