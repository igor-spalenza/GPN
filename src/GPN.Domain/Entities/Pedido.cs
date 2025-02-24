using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPN.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; private set; }
        public int ClienteId { get; private set; }
        public string DataPedido { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataModificacao { get; set; }

    }
}
