using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PED_CAFETERIA.Clases
{
   
      public class HistorialPedidos
    {
        public NodoHistorial Primero;
        public NodoHistorial Ultimo;

        public void Agregar(string cliente, string productos, string total)
        {
            NodoHistorial nuevo = new NodoHistorial(cliente, productos, total);

            if (Primero == null)
            {
                Primero = nuevo;
                Ultimo = nuevo;
            }
            else
            {
                Ultimo.siguiente = nuevo;
                Ultimo = nuevo;
            }
        }
        public void EliminarPorSeleccion(int index)
        {
            if (Primero == null)
                return;

            NodoHistorial actual = Primero;
            NodoHistorial anterior = null;

            int contador = 0;

            while (actual != null)
            {
                if (contador == index)
                {
                    if (anterior == null)
                    {
                        Primero = actual.siguiente;
                    }
                    else
                    {
                        anterior.siguiente = actual.siguiente;
                    }

                    return;
                }

                anterior = actual;
                actual = actual.siguiente;
                contador++;
            }
        }
    }

}