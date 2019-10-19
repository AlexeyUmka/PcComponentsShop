using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcComponentsShop.Domain.Core.Basic_Models;

namespace PcComponentsShop.Domain.Interfaces.Basic_Interfaces
{
    public interface IRepositoryFIlter<TElementsType> where TElementsType:class
    {
        IEnumerable<TElementsType> ExecuteAndReturn(IQueryable<TElementsType> elelments);
    }
}
