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
    }

}