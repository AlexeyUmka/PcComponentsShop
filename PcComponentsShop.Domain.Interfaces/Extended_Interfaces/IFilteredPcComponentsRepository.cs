using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;
using System.Collections.Generic;

namespace PcComponentsShop.Domain.Interfaces.Extended_Interfaces
{
    /// <summary>
    /// Represents a filtered part of IRepository, which will be return elements depend on IRepositoryFilter
    /// </summary>
    /// <typeparam name="T">Type of returned elements</typeparam>
    public interface IFilteredPcComponentsRepository<T> : IRepository<T> where T : Good
    {
        IEnumerable<Good> GetAll(IPcComponentsRepositoryFilter repositoryFIlter);
    }
}
