
using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<object> CreateToken(AppUser user);
    }
}
