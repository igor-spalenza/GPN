using GPN.Application.DTOs;
using GPN.Application.Interfaces;
using GPN.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return new PedidoDto
            {
                PedidoId = pedido.PedidoId,
                ClienteId = pedido.ClienteId,
                DataCadastro = pedido.DataCadastro,
                DataPedido = pedido.DataPedido,
                DataModificacao = pedido.DataModificacao
            };
        }

        public Task AddAsync(PedidoCreateDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PedidoIndexVendasDto>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return pedidos.Select(p => new PedidoIndexVendasDto
            {
                PedidoId = p.PedidoId,
                ClienteId= p.ClienteId,
                DataCadastro = p.DataCadastro,
                DataPedido= p.DataPedido,
                DataModificacao= p.DataModificacao
            });
        }

        public Task UpdateAsync(PedidoUpdateDto clienteDto)
        {
            throw new NotImplementedException();
        }
    }
}
