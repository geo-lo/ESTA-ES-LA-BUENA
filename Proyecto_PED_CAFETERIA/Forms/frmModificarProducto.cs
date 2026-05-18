using System;
using Proyecto_PED_CAFETERIA.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class frmModificarProducto : Form
    {
        public frmModificarProducto()
        {
            InitializeComponent();
        }

        private void frmModificarProducto_Load_1(object sender, EventArgs e)
        {
            // Cargar las categorías disponibles en el ComboBox
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[] { "Comidas", "Bebidas", "Antojitos", "Mas" });
            cmbCategoria.SelectedIndex = 0;

            // Si estamos editando, cargar los datos actuales del producto
            if (!string.IsNullOrEmpty(idRecibido) && int.TryParse(idRecibido, out int id))
            {
                ConsultasDB repo = new ConsultasDB();
                DataTable info = repo.BuscarPorId(id);

                if (info.Rows.Count > 0)
                {
                    DataRow fila = info.Rows[0];
                    txtNombre.Text   = fila["NombreProducto"].ToString();
                    txtCantidad.Text = fila["CantidadActual"].ToString();
                    txtPrecio.Text   = fila["PrecioUnitario"].ToString();

                    if (info.Columns.Contains("Categoria"))
                    {
                        string cat = fila["Categoria"].ToString();
                        int idx = cmbCategoria.Items.IndexOf(cat);
                        cmbCategoria.SelectedIndex = idx >= 0 ? idx : 0;
                    }

                    if (info.Columns.Contains("Descripcion"))
                        txtDescripcion.Text = fila["Descripcion"].ToString();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConsultasDB repo = new ConsultasDB();

            // 1. Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text)    ||
                string.IsNullOrWhiteSpace(txtCantidad.Text)  ||
                string.IsNullOrWhiteSpace(txtPrecio.Text)    ||
                cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // 2. Validación de formato numérico
            if (!int.TryParse(txtCantidad.Text, out int cantidad) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.");
                return;
            }

            if (precio < 0 || cantidad < 0)
            {
                MessageBox.Show("Por favor, ingrese valores positivos.");
                return;
            }

            string categoria   = cmbCategoria.SelectedItem.ToString();
            string descripcion = txtDescripcion.Text.Trim();

            try
            {
                // 3. Insertar o Editar según si recibimos un ID
                if (string.IsNullOrEmpty(idRecibido))
                {
                    repo.Insertar(txtNombre.Text, cantidad, (double)precio, categoria, descripcion);
                    MessageBox.Show("Producto agregado con éxito.");
                }
                else
                {
                    if (int.TryParse(idRecibido, out int id))
                    {
                        repo.EditarProducto(id, txtNombre.Text, cantidad, 5, precio, categoria, descripcion);
                        MessageBox.Show("Producto modificado con éxito.");
                    }
                }

                // 4. Avisar al Inventario que refresque y cerrar
                refrescar?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar: " + ex.Message);
            }
        }

        public event Action refrescar;
        public string idRecibido;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
