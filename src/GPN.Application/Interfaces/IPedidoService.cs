using GPN.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDto> GetByIdAsync(int id);
        Task<IEnumerable<PedidoViewIndexDto>> GetAllAsync();
        Task AddAsync(PedidoCreateDto clienteDto);
        Task UpdateAsync(PedidoUpdateDto clienteDto);
        Task DeleteAsync(int id);
    }
}
