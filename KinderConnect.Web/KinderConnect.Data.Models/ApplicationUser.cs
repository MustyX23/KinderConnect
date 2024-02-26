using Microsoft.AspNetCore.Identity;

namespace KinderConnect.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            Id = Guid.NewGuid();
        }
    }
}
