using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public int? PersonaId { get; set; }
    
    [InverseProperty("AppUserAuthorized")]
    public List<BitacoraFicha> AppUserAuthorizeds { get; set; } = new List<BitacoraFicha>();
}    
