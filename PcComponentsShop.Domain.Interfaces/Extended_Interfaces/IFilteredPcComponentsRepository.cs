using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;
using PcComponentsShop.Domain.Core.Basic_Models;

namespace PcComponentsShop.Domain.Interfaces.Extended_Interfaces
{
    public interface IFilteredPcComponentsRepository<T> : IRepository<T> where T : Good
    {
        IEnumerable<Good> GetAll(IPcComponentsRepositoryFilter repositoryFIlter);
    }
}
