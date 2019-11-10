using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    /// <summary>
    /// Represents a CreateUser model for view(fields set with data annotations)
    /// </summary>
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    /// <summary>
    /// Represents a Login model for view(fields set with data annotations)
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
    /// <summary>
    /// Represents a RoleEdit model for view(fields set with data annotations)
    /// </summary>
    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }
    /// <summary>
    /// Represents a RoleModification model for view(fields set with data annotations)
    /// </summary>
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}
