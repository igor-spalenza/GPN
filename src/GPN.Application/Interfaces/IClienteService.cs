using GPN.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> GetByIdAsync(int id);
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task AddAsync(ClienteDto clienteDto);
        Task UpdateAsync(ClienteDto clienteDto);
        Task DeleteAsync(int id);
    }
}
