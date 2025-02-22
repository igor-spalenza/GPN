﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken);
        Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
        Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken);
        Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken);
        Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken);
    }
}
