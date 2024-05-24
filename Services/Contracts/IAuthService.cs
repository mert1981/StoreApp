
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Security.Principal;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }

        IEnumerable<IdentityUser> GetAllUsers();
        //userDtoforUpdate deki role alanları da alabilmek için bu tanımı yazdık
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);

        Task<IdentityUser> GetOneUser(string userName);
        Task Update(UserDtoForUpdate userDto);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);
    }
}
