using GPN.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CustomUserStore _userStore;

        public UserRepository(CustomUserStore userStore)
        {
            _userStore = userStore;
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return _userStore.FindByIdAsync(userId, cancellationToken);
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return _userStore.FindByNameAsync(normalizedUserName, cancellationToken);
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return _userStore.CreateAsync(user, cancellationToken);
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return _userStore.UpdateAsync(user, cancellationToken);
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return _userStore.DeleteAsync(user, cancellationToken);
        }
    }
}
