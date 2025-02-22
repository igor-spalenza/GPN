using GPN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.DTOs
{
    public class ClienteCreateDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string TelefonePrincipal { get; set; }
        public DateTime DataCadastro { get; set; }

        public ClienteCreateDto()
        {

        }

        public ClienteCreateDto(Cliente cliente)
        {
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            TelefonePrincipal = cliente.TelefonePrincipal;
            DataCadastro = DateTime.Now;
        }
    }
}
