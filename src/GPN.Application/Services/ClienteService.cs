using GPN.Application.DTOs;
using GPN.Application.Interfaces;
using GPN.Domain.Entities;
using GPN.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                TelefonePrincipal = cliente.TelefonePrincipal,
                DataCadastro = cliente.DataCadastro
            };
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(c => new ClienteDto
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                TelefonePrincipal = c.TelefonePrincipal,
                DataCadastro = c.DataCadastro
            });
        }

        public async Task AddAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                TelefonePrincipal = clienteDto.TelefonePrincipal,
                DataCadastro = DateTime.Now
            };
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                ClienteId = clienteDto.ClienteId,
                Nome = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                TelefonePrincipal = clienteDto.TelefonePrincipal,
            };
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
