using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Domain.Entities
{
    public class Pedido
    {
        public string PedidoId { get; private set; }
        public string ClienteId { get; private set; }
        public string ColaboradorId { get; private set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataModificacao { get; set; }

    }
}
