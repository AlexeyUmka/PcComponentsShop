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
    public class PowerSupplyRepository : PcComponentsRepository<PowerSupply>
    {
        public PowerSupplyRepository(PcComponentsShopContext context, DbSet<PowerSupply> table)
            : base(context, table)
        { }
    }
}
