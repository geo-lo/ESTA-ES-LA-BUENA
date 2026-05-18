using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class Nodo_ListaProductos
    {
        public Producto ProductoGuardado;
        public Nodo_ListaProductos siguiente;

        public Nodo_ListaProductos(Producto producto)
        {
            ProductoGuardado = producto;
            siguiente = null;
        }
    }
}
