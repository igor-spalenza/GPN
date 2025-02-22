using GPN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.DTOs
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string TelefonePrincipal { get; set; }
        public DateTime DataCadastro { get; set; }

        public ClienteDto()
        {

        }

        public ClienteDto(Cliente cliente)
        {
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            TelefonePrincipal = cliente.TelefonePrincipal;

        }
    }
}
