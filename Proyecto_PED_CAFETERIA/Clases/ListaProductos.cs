using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class ListaProductos
    {
        public Nodo_ListaProductos Primero;
       
       

        public string ObtenerProductosTexto()
        {
            if (Primero == null)
            {
                return "Sin productos";
            }

            StringBuilder texto = new StringBuilder();
            Nodo_ListaProductos actual = Primero;

            while (actual != null)
            {
                texto.Append (actual.ProductoGuardado.NombreProducto
                      + " x"
                      + actual.ProductoGuardado.Cantidad);

                
                if (actual.siguiente != null)
                {
                    texto.AppendLine();
                }

                actual = actual.siguiente;
            }

            return texto.ToString();
        }
        


        //metodo para eliminar un producto del carrito
        public void EliminarProducto(string nombreProducto)
        {
            if (Primero == null)
            {
                return;
            }
            if (Primero.ProductoGuardado.NombreProducto.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
            {
                Primero = Primero.siguiente;
                return;
            }
            Nodo_ListaProductos actual = Primero;
            while (actual.siguiente != null)
            {
                if (actual.siguiente.ProductoGuardado.NombreProducto.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
                {
                    actual.siguiente = actual.siguiente.siguiente;
                    return;
                }
                actual = actual.siguiente;
            }
        }

        public void AgregarProducto(Producto p)
        {
            Nodo_ListaProductos nuevo = new Nodo_ListaProductos(p);

            if (Primero == null)
            {
                Primero = nuevo;
            }
            else
            {
                Nodo_ListaProductos actual = Primero;

                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }

                actual.siguiente = nuevo;
            }
        }
    }
}
