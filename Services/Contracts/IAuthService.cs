
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }

        IEnumerable<IdentityUser> GetAllUsers();

        
    }
}
