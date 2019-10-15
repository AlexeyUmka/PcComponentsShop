using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class ComputerСaseRepository : PcComponentsRepository<ComputerCase>
    {
        public ComputerСaseRepository(PcComponentsShopContext context, DbSet<ComputerCase> table)
            :base(context, table)
        { }
    }
}
