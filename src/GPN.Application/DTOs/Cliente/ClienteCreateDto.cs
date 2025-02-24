using GPN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        
        [Display(Name = "Telefone Principal")]
        public string TelefonePrincipal { get; set; }
        
        [Display(Name = "Data de Criação")]
        public DateTime DataCadastro { get; set; }

        public ClienteCreateDto()
        {

        }

        public ClienteCreateDto(Cliente cliente)
        {
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            Cpf = cliente.Cpf;
            TelefonePrincipal = cliente.TelefonePrincipal;
            DataCadastro = DateTime.Now;
        }
    }
}
