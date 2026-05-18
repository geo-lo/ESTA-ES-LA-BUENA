using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class Nodo_ColaPedidos
    {
        public Pedido PedidoGuardado;
        public Nodo_ColaPedidos siguiente;

        public Nodo_ColaPedidos(Pedido pedido)
        {
            PedidoGuardado = pedido;
            siguiente = null;
        }
    }
}
