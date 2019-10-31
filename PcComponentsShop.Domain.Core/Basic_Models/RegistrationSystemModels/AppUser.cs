using Microsoft.AspNet.Identity.EntityFramework;

namespace PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels
{
    public class AppUser : IdentityUser
    {
        public string GoodsInBasket { get; set; }
        public string GoodsWishes { get; set; }
    }
}
