using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PED_CAFETERIA.Clases
{
    public class NodoHistorial
    {
        public string Cliente;
        public string Productos;
        public string Total;

        public NodoHistorial siguiente;

        public NodoHistorial(string cliente, string productos, string total)
        {
            Cliente = cliente;
            Productos = productos;
            Total = total;
            siguiente = null;
        }
    }
}
