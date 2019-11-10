using Microsoft.AspNet.Identity.EntityFramework;

namespace PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels
{
    /// <summary>
    /// Inherits from IdentitiyUser, it's a custom realization of this class
    /// </summary>
    public class AppUser : IdentityUser
    {
        public string GoodsInBasket { get; set; }
        public string GoodsWishes { get; set; }
    }
}
