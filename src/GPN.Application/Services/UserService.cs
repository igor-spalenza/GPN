﻿using GPN.Application.Interfaces;
using GPN.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityUser> GetUserByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _userRepository.FindByIdAsync(userId, cancellationToken);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password, CancellationToken cancellationToken)
        {
            // Aqui você pode adicionar lógica adicional, como hashing de senha
            return await _userRepository.CreateAsync(user, cancellationToken);
        }

        public async Task<IdentityResult> UpdateUserAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateAsync(user, cancellationToken);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(userId, cancellationToken);
            return await _userRepository.DeleteAsync(user, cancellationToken);
        }
    }
}
