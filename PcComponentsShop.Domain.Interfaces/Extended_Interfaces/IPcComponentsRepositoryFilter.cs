using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;

namespace PcComponentsShop.Domain.Interfaces.Extended_Interfaces
{
    /// <summary>
    /// More specific realization of IRepositoryFilter for PcComponentsRepository
    /// </summary>
    public interface IPcComponentsRepositoryFilter : IRepositoryFIlter<Good>
    {
    }
}
