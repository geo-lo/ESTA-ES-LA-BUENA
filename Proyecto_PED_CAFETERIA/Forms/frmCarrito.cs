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
    public partial class frmCarrito : Form
    {
        public frmCarrito()
        {
            InitializeComponent();
        }

        private void frmCarrito_Load(object sender, EventArgs e)
        {
            AplicarEstiloCarrito();
            MostrarCarrito();
        }

        private void AplicarEstiloCarrito()
        {
            this.BackColor = Color.FromArgb(250, 244, 236); // crema
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Carrito";

            flowCarrito.BackColor = Color.White;
            flowCarrito.AutoScroll = true;
            flowCarrito.WrapContents = false;
            flowCarrito.FlowDirection = FlowDirection.TopDown;
            flowCarrito.Padding = new Padding(10);

            lblTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(92, 64, 51);
            lblTotal.BackColor = Color.Transparent;

            btnRegresar.BackColor = Color.FromArgb(170, 60, 60);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegresar.Cursor = Cursors.Hand;

            btnRegresar.MouseEnter += (s, e) =>
            {
                btnRegresar.BackColor = Color.FromArgb(145, 45, 45);
            };

            btnRegresar.MouseLeave += (s, e) =>
            {
                btnRegresar.BackColor = Color.FromArgb(170, 60, 60);
            };
        }

        public void MostrarCarrito()
        {
            flowCarrito.Controls.Clear();

            if (ClaseGlobal.listaTemporal == null)
            {
                lblTotal.Text = "Total: $0.00";
                return;
            }

            Nodo_ListaProductos actual = ClaseGlobal.listaTemporal.Primero;

            while (actual != null)
            {
                var producto = actual.ProductoGuardado;

                Panel card = new Panel();
                card.Width = 430;
                card.Height = 100;
                card.BackColor = Color.FromArgb(245, 242, 222); // beige suave
                card.Margin = new Padding(8);
                card.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pic = new PictureBox
                {
                   
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 70,
                    Height = 70,
                    Location = new Point(10, 15),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None
                };

                Label lblNombre = new Label
                {
                    Text = producto.NombreProducto,
                    Location = new Point(95, 12),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(70, 45, 30),
                    BackColor = Color.Transparent
                };

                Label lblCantidad = new Label
                {
                    Text = "Cantidad: x" + producto.Cantidad,
                    Location = new Point(95, 40),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.FromArgb(70, 45, 30),
                    BackColor = Color.Transparent
                };

                Label lblPrecio = new Label
                {
                    Text = "Precio: $" + (producto.Cantidad * producto.Precio).ToString("0.00"),
                    Location = new Point(95, 65),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(92, 64, 51),
                    BackColor = Color.Transparent
                };

                Button btnEliminar = new Button
                {
                    Text = "-",
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(190, 60, 60),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 38,
                    Height = 34,
                    Location = new Point(370, 52),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 190);
                btnEliminar.FlatAppearance.BorderSize = 1;

                Button btnAgregar = new Button
                {
                    Text = "+",
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(60, 150, 70),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Width = 38,
                    Height = 34,
                    Location = new Point(370, 12),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(220, 210, 190);
                btnAgregar.FlatAppearance.BorderSize = 1;

                btnEliminar.MouseEnter += (s, e) =>
                {
                    btnEliminar.BackColor = Color.FromArgb(255, 245, 245);
                };
                btnEliminar.MouseLeave += (s, e) =>
                {
                    btnEliminar.BackColor = Color.White;
                };

                btnAgregar.MouseEnter += (s, e) =>
                {
                    btnAgregar.BackColor = Color.FromArgb(245, 255, 245);
                };
                btnAgregar.MouseLeave += (s, e) =>
                {
                    btnAgregar.BackColor = Color.White;
                };

                btnEliminar.Click += (s, e) =>
                {
                    if (producto.Cantidad > 1)
                    {
                        producto.Cantidad--;
                    }
                    else
                    {
                        ClaseGlobal.listaTemporal.EliminarProducto(producto.NombreProducto);
                    }

                    MostrarCarrito();
                };

                btnAgregar.Click += (s, e) =>
                {
                    Nodo_ListaProductos aux = ClaseGlobal.listaTemporal.Primero;

                    while (aux != null)
                    {
                        if (aux.ProductoGuardado.NombreProducto == producto.NombreProducto)
                        {
                            aux.ProductoGuardado.Cantidad++;
                            break;
                        }

                        aux = aux.siguiente;
                    }

                    MostrarCarrito();
                };

                card.Controls.Add(pic);
                card.Controls.Add(lblNombre);
                card.Controls.Add(lblCantidad);
                card.Controls.Add(lblPrecio);
                card.Controls.Add(btnEliminar);
                card.Controls.Add(btnAgregar);

                flowCarrito.Controls.Add(card);

                actual = actual.siguiente;
            }

            lblTotal.Text = "Total: $" + CalcularTotalCarrito().ToString("0.00");
        }

        public double CalcularTotalCarrito()
        {
            double total = 0;

            if (ClaseGlobal.listaTemporal == null)
                return total;

            Nodo_ListaProductos actual = ClaseGlobal.listaTemporal.Primero;

            while (actual != null)
            {
                total += actual.ProductoGuardado.Cantidad * actual.ProductoGuardado.Precio;
                actual = actual.siguiente;
            }

            return total;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void flowCarrito_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}