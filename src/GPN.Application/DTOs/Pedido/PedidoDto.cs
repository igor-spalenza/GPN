using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Application.DTOs
{
    public class PedidoDto
    {
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string ColaboradorId { get; set; }

        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Modificação")]
        public DateTime DataModificacao { get; set; }
    }
}
