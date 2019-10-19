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
    public class SSDDriveRepository : PcComponentsRepository<SSDDrive>
    {
        public SSDDriveRepository(PcComponentsShopContext context, DbSet<SSDDrive> table)
            : base(context, table)
        { }
    }
}