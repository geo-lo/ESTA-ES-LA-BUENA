using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class Pedido
    {
        public string nombreCliente;
        public ListaProductos ProductosSeleccionados;
        public double Total;

        public Pedido( ListaProductos lista,string nombreP)
        {
            nombreCliente = nombreP;
            ProductosSeleccionados = lista;
            Total = CalcularTotal();
        }
        public Double CalcularTotal()
        { 
            Double total = 0;
            Nodo_ListaProductos actual = ProductosSeleccionados.Primero;
            while (actual!=null)
            {
                total += actual.ProductoGuardado.Total;
                actual = actual.siguiente;
            }
            return total;
        }

        public void AgregarProducto(Producto p)
        {
            ProductosSeleccionados.AgregarProducto(p);
            Total += p.Total;
        }
    }
}


