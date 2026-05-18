using CAFETERIA.ClasesNuevas;
using Proyecto_PED_CAFETERIA.Clases;
using System;
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
    public partial class frmCantidad : Form
    {
        // Variables para almacenar la información del producto seleccionado
        string nombreProducto;
        double precioProducto;
        string DescripcionProducto;

        public frmCantidad()
        {
            InitializeComponent();
        }

        // Constructor del formulario de cantidad que recibe el nombre del producto,
        // su precio, la imagen y la descripción
        public frmCantidad(string nombre, double precio, string descripcionProducto)
        {
            InitializeComponent();
            nombreProducto = nombre;
            precioProducto = precio;
            DescripcionProducto = descripcionProducto;
        }

        // Al cargar el formulario de cantidad, se muestra la imagen del producto,
        // su descripción y se configura el estilo del texto
        private void frmCantidad_Load(object sender, EventArgs e)
        {
            AplicarEstiloBonito();

            lblPre.Text = "Precio: $" + precioProducto.ToString("0.00");
            lblPre.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            txtDesc.Text = DescripcionProducto;
            txtDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtDesc.SelectionStart = 0;
            txtDesc.SelectionLength = 0;
            txtDesc.BackColor = Color.White;
            txtDesc.ForeColor = Color.FromArgb(70, 45, 30);
            txtDesc.BorderStyle = BorderStyle.None;
            txtDesc.ReadOnly = true;

            

            numericUpDown1.Value = 1;
            actualizarPrecio();
        }

        private void AplicarEstiloBonito()
        {
            // FORMULARIO
            this.BackColor = Color.FromArgb(250, 244, 236); // crema
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Cantidad";

            // LABEL PRECIO
            lblPre.ForeColor = Color.FromArgb(92, 64, 51);
            lblPre.BackColor = Color.Transparent;

            // DESCRIPCION
            txtDesc.BackColor = Color.White;
            txtDesc.ForeColor = Color.FromArgb(70, 45, 30);
            txtDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // IMAGEN
            imagen.BackColor = Color.White;
            imagen.BorderStyle = BorderStyle.FixedSingle;
            imagen.SizeMode = PictureBoxSizeMode.Zoom;

            // NUMERICUPDOWN
            numericUpDown1.BackColor = Color.White;
            numericUpDown1.ForeColor = Color.FromArgb(70, 45, 30);
            numericUpDown1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;

            // BOTON ACEPTAR
            btnAceptar.BackColor = Color.FromArgb(120, 150, 90);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnAceptar.Cursor = Cursors.Hand;

            // BOTON SALIR
            btnSalir.BackColor = Color.FromArgb(170, 60, 60);
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSalir.Cursor = Cursors.Hand;

            // EFECTOS DE MOUSE
            btnAceptar.MouseEnter += (s, e) =>
            {
                btnAceptar.BackColor = Color.FromArgb(100, 130, 75);
            };

            btnAceptar.MouseLeave += (s, e) =>
            {
                btnAceptar.BackColor = Color.FromArgb(120, 150, 90);
            };

            btnSalir.MouseEnter += (s, e) =>
            {
                btnSalir.BackColor = Color.FromArgb(145, 45, 45);
            };

            btnSalir.MouseLeave += (s, e) =>
            {
                btnSalir.BackColor = Color.FromArgb(170, 60, 60);
            };
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
        }

        // Método para validar la cantidad ingresada por el usuario
        public void validarCantidad()
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Ingrese una cantidad", "AVISO");
                numericUpDown1.Focus();
                return;
            }

            int cantidad = (int)numericUpDown1.Value;
            // DESPUÉS
            Producto prod = new Producto(nombreProducto, 0, cantidad, precioProducto, btnAceptar, "Categoria", DescripcionProducto);

            ClaseGlobal.listaTemporal.AgregarProducto(prod);

            MessageBox.Show("Producto agregado al carrito", "ÉXITO");
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            validarCantidad();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            actualizarPrecio();
        }

        // Método para actualizar el precio total
        private void actualizarPrecio()
        {
            int cantidad = (int)numericUpDown1.Value;
            double precioTotal = cantidad * precioProducto;
            lblPre.Text = "Precio: $" + precioTotal.ToString("0.00");
        }

        private void frmCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarCantidad();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
