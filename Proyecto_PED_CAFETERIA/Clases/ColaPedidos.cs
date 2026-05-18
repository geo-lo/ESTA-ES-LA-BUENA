using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class ColaPedidos
    {
        public Nodo_ColaPedidos Primero;
        public Nodo_ColaPedidos Ultimo;


        public void Encolar(Pedido p)
        {
            Nodo_ColaPedidos nuevo = new Nodo_ColaPedidos(p);
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
        public Pedido EliminarPorSeleccion(int index)
        {
            if (Primero == null) return null;

            Nodo_ColaPedidos actual = Primero;
            Nodo_ColaPedidos anterior = null;
            int contador = 0;

            while (actual != null)
            {
                if (contador == index)
                {
                    Pedido eliminado = actual.PedidoGuardado;

                    if (anterior == null)
                    {
                      
                        Primero = actual.siguiente;
                        if (Primero == null)
                            Ultimo = null;
                    }
                    else
                    {
                        anterior.siguiente = actual.siguiente;

                        if (actual == Ultimo)
                            Ultimo = anterior;
                    }

                    return eliminado;
                }

                anterior = actual;
                actual = actual.siguiente;
                contador++;
            }

            return null;
        }

        public Pedido Desencolar()
        {
            if (Primero == null)

                return null;
            Pedido pedidoDesencolado = Primero.PedidoGuardado;
            Primero = Primero.siguiente;
            if (Primero == null)
                Ultimo = null;
            return pedidoDesencolado;
        }
    }
   
}
