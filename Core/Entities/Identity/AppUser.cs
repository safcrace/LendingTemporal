using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public Persona? Person { get; set; }
    //public ICollection<BusinessUser> BusinessUsers { get; set; } = new List<BusinessUser>();
}    
