using System.Collections.Generic;

namespace PcComponentsShop.Domain.Interfaces.Basic_Interfaces
{
    /// <summary>
    /// Represents a default repository(Pattern Repository)
    /// </summary>
    /// <typeparam name="TElementsType">Elements type of repository</typeparam>
    public interface IRepository<TElementsType> where TElementsType:class
    {
        IEnumerable<TElementsType> GetAll();
        TElementsType GetElement(int id);
        void Create(TElementsType item);
        void Update(TElementsType item);
        void Delete(int id);
    }
}
