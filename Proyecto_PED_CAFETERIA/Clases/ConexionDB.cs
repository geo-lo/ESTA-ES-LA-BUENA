using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //libreria necesaria para db

namespace Proyecto_PED_CAFETERIA.Clases
{
    internal class ConexionDB
    {
        //cadena de conexion a la base de datos
        private readonly string connectionString = "Server=localhost; Database=CafeteriaDB; Integrated Security=True;";

        //objeto de conexion
        protected SqlConnection connection;

        //Metodo para obtenr la conexion a la base de datos
        public SqlConnection AbrirConexion()
        {
            connection = new SqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        //Metodo para cerrar la conexion a la base de datos
        public void CerrarConexion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose(); //Liberar recursos
            }

        }
    }
}
