using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            Id = Guid.NewGuid();
        }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
