using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken);
        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, CancellationToken cancellationToken);
        Task<IdentityResult> UpdateUserAsync(IdentityUser user, CancellationToken cancellationToken);
        Task<IdentityResult> DeleteUserAsync(string userId, CancellationToken cancellationToken);
    }
}
