using CAFETERIA.ClasesNuevas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PED_CAFETERIA.Clases
{
    internal class ClaseGlobal
    {
        // Esta clase se utiliza para almacenar variables globales
        // que pueden ser accedidas desde cualquier parte del programa
        public static ColaPedidos colaPedidos = new ColaPedidos();

        // La lista temporal se utiliza para almacenar
        // los productos seleccionados por el cliente
        // cumple la funcion de un carrito
        public static ListaProductos listaTemporal = new ListaProductos();

        public static HistorialPedidos historial = new HistorialPedidos();

    }
}
