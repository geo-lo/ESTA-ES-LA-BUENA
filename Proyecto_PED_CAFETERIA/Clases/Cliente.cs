using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERIA.ClasesNuevas
{
    public class Cliente
    {
        private static int contador = 1;

        public int ID { get; set; }
        public string Nombre { get; set; }

        public Cliente(string nombre)
        {
            ID = contador++;
            Nombre = nombre;
        }
    }
}
