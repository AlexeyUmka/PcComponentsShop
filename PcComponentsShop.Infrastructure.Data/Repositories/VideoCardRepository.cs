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
    public class VideoCardRepository : PcComponentsRepository<VideoCard>
    {
        public VideoCardRepository(PcComponentsContext context, DbSet<VideoCard> table)
            : base(context, table)
        { }
    }
}