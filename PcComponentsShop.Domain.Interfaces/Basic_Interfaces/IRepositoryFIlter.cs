using System.Collections.Generic;
using System.Linq;

namespace PcComponentsShop.Domain.Interfaces.Basic_Interfaces
{
    /// <summary>
    /// Represents a default filter which will be return elements of repository under the condition
    /// </summary>
    /// <typeparam name="TElementsType">Elements type of repository</typeparam>
    public interface IRepositoryFIlter<TElementsType> where TElementsType:class
    {
        IEnumerable<TElementsType> ExecuteAndReturn(IQueryable<TElementsType> elelments);
    }
}
