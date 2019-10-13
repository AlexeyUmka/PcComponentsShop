using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class ProcessorRepository : PcComponentsRepository<Processor>
    {
        public ProcessorRepository(PcComponentsContext context, DbSet<Processor> table)
            : base(context, table)
        { }
    }
}
