using Microsoft.AspNet.Identity.EntityFramework;

namespace PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels
{
    /// <summary>
    /// Inherits from IdentitiyRole, it's a custom realization of this class
    /// </summary>
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name)
            : base(name)
        { }
    }
}
