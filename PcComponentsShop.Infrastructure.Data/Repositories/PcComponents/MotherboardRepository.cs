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
    public class MotherboardRepository : PcComponentsRepository<Motherboard>
    {
        public MotherboardRepository(PcComponentsShopContext context, DbSet<Motherboard> table)
            : base(context, table)
        { }
    }
}
