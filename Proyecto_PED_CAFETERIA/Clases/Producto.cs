using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFETERIA.ClasesNuevas
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public Double Precio { get; set; }
        public Button Boton { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }

        public double Total
        {
            get { return Cantidad * Precio; }
        }

        public Producto(string nombreProducto, int id, int cantidad, double precio, Button boton, string categoria, string descripcion, string rutaImagen)
        {
            NombreProducto = nombreProducto;
            Id = id;
            Cantidad = cantidad;
            RutaImagen = rutaImagen;
            Precio = precio;
            Boton = boton;
            Categoria = categoria;
            Descripcion = descripcion;
        }
    }
}