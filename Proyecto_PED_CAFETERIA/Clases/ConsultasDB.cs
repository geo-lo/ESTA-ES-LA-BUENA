using CAFETERIA.ClasesNuevas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Clases
{
    internal class ConsultasDB : ConexionDB
    {

        //Obtener datos (Select) de la tabla Inventario
        public DataTable MostrarInventario()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT IdProducto, NombreProducto, CantidadActual, PrecioUnitario, Categoria, Descripcion FROM Inventario";

            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);

            leer.Close();
            CerrarConexion();
            return tabla;
        }

        //Insertar datos (Insert) en la tabla Inventario
        public void Insertar(string nombre, int cantidad, double precio, string categoria = "", string descripcion = "")
        {
            if (ExisteProducto(nombre))
            {
                MessageBox.Show("El producto ya existe en el inventario.");
                return;
            }

            SqlCommand comando = new SqlCommand();
            comando.Connection = AbrirConexion();
            comando.CommandText = @"INSERT INTO Inventario (NombreProducto, CantidadActual, PrecioUnitario, Categoria, Descripcion) 
                                    VALUES (@nombre, @cantidad, @precio, @categoria, @descripcion)";
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.Parameters.AddWithValue("@descripcion", descripcion);

            comando.ExecuteNonQuery();
            CerrarConexion();
        }


        //Eliminar datos (Delete) de la tabla Inventario
        public void EliminarProducto(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = AbrirConexion();
            comando.CommandText = "DELETE FROM Inventario WHERE IdProducto = @id"; //Consulta SQL para eliminar un producto por su ID
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            CerrarConexion();
        }
        //Buscar producto por nombre en la tabla Inventario
        public DataTable BuscarPorId(int id)
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = AbrirConexion();

            // Usamos el parámetro @id para filtrar la búsqueda
            comando.CommandText = "SELECT * FROM Inventario WHERE IdProducto = @id";
            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);

            leer.Close();
            CerrarConexion();

            return tabla;
        }

        // Función auxiliar privada para validar existencia de un producto por su nombre
        private bool ExisteProducto(string nombre)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT COUNT(*) FROM Inventario WHERE NombreProducto = @nombre";
            comando.Parameters.AddWithValue("@nombre", nombre);

            int conteo = Convert.ToInt32(comando.ExecuteScalar());
            CerrarConexion();

            return conteo > 0;
        }

        //funcion para editar un producto por su ID, retorna true si se editó correctamente, false si no se encontró el ID
        public bool EditarProducto(int id, string nombre, int cantidad, int stockMin, decimal precio, string categoria = "", string descripcion = "")
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = AbrirConexion();

                comando.CommandText = @"UPDATE Inventario 
                                SET NombreProducto = @nombre, 
                                    CantidadActual = @cantidad, 
                                    StockMinimo = @stockMin, 
                                    PrecioUnitario = @precio,
                                    Categoria = @categoria,
                                    Descripcion = @descripcion,
                                    UltimaActualizacion = GETDATE() 
                                WHERE IdProducto = @id";

                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@stockMin", stockMin);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@categoria", categoria);
                comando.Parameters.AddWithValue("@descripcion", descripcion);

                int filasAfectadas = comando.ExecuteNonQuery();
                CerrarConexion();

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                CerrarConexion();
                throw new Exception("Error al editar el producto: " + ex.Message);
            }
        }
        
        //Consulta para guardar el historial de pedidos en la base de datos
        public void RegistrarVenta(string nombre, int cantidad, decimal precio, string cliente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = AbrirConexion();
            comando.CommandText = @"INSERT INTO HistoriaVentas
                                    (NombreProducto, CantidadVendida, PrecioVenta, NombreCliente)
                                    VALUES ( @nombre, @cantidad, @precio, @cliente)";
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cliente", cliente);

            comando.ExecuteNonQuery();
            CerrarConexion();
        }

        //Obtiene los datos del historial de ventas de la DB
        public DataTable MostrarHistorialVentas()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = AbrirConexion();
            comando.CommandText = "SELECT IdRegistro, NombreCliente, NombreProducto, CantidadVendida , TotalVenta, FechaVenta FROM HistoriaVentas ORDER BY FechaVenta DESC";

            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);

            leer.Close();
            CerrarConexion();
            return tabla;
        }

    }
}
