using CAFETERIA.ClasesNuevas;
using Proyecto_PED_CAFETERIA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class frmColaPedidos : Form
    {
        public frmColaPedidos()
        {
            InitializeComponent();
        }

        private void frmColaPedidos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            AplicarEstiloBonito();

            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(92, 64, 51);
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Text = "COLA DE PEDIDOS";

            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;
            dgvPedidos.ReadOnly = true;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            MostrarPedidos();
            estiloDataGrid(dgvPedidos);

            foreach (DataGridViewColumn col in dgvPedidos.Columns)
            {
                col.Frozen = false;
            }
        }

        private void ConfigurarGrid()
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.Rows.Clear();
            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPedidos.Columns.Add("Cliente", "Cliente");
            dgvPedidos.Columns.Add("Productos", "Productos");
            dgvPedidos.Columns.Add("Total", "Total");
        }

        public void MostrarPedidos()
        {
            dgvPedidos.Rows.Clear();
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (ClaseGlobal.colaPedidos == null)
                return;

            Nodo_ColaPedidos actual = ClaseGlobal.colaPedidos.Primero;

            while (actual != null)
            {
                Pedido p = actual.PedidoGuardado;

                if (p != null)
                {
                    string productoTexto = "";

                    if (p.ProductosSeleccionados != null)
                    {
                        productoTexto = p.ProductosSeleccionados.ObtenerProductosTexto();
                    }

                    dgvPedidos.Rows.Add(
                        p.nombreCliente,
                        productoTexto,
                        p.CalcularTotal().ToString("0.00") + "$"
                    );
                }

                actual = actual.siguiente;
            }
        }

        private void estiloDataGrid(DataGridView dataHistorial)
        {
            dataHistorial.BackgroundColor = Color.White;
            dataHistorial.BorderStyle = BorderStyle.None;
            dataHistorial.EnableHeadersVisualStyles = false;
            dataHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataHistorial.RowHeadersVisible = false;

            dataHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataHistorial.MultiSelect = false;
            dataHistorial.ReadOnly = true;

            dataHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 72, 40);
            dataHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataHistorial.ColumnHeadersHeight = 38;

            dataHistorial.DefaultCellStyle.BackColor = Color.White;
            dataHistorial.DefaultCellStyle.ForeColor = Color.FromArgb(70, 45, 30);
            dataHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 200, 170);
            dataHistorial.DefaultCellStyle.SelectionForeColor = Color.FromArgb(70, 45, 30);

            dataHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 248, 243);
            dataHistorial.GridColor = Color.FromArgb(230, 220, 210);
            dataHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un pedido", "Aviso");
                return;
            }

            int index = dgvPedidos.SelectedRows[0].Index;
            Pedido pedido = ClaseGlobal.colaPedidos.EliminarPorSeleccion(index);

            if (pedido == null)
            {
                MessageBox.Show("Error al procesar pedido");
                return;
            }

            // Guardar en BD
            ConsultasDB repo = new ConsultasDB();
            Nodo_ListaProductos actual = pedido.ProductosSeleccionados.Primero;
            while (actual != null)
            {
                Producto p = actual.ProductoGuardado;
                repo.RegistrarVenta(p.NombreProducto, p.Cantidad, (decimal)p.Precio);
                actual = actual.siguiente;
            }

            string cliente = pedido.nombreCliente;
            string productos = pedido.ProductosSeleccionados.ObtenerProductosTexto();
            string total = "$" + pedido.CalcularTotal().ToString("0.00");

            ClaseGlobal.historial.Agregar(cliente, productos, total);
            MostrarPedidos();

            MessageBox.Show("Pedido procesado y guardado correctamente", "Éxito");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AplicarEstiloBonito()
        {
            this.BackColor = Color.FromArgb(250, 244, 236);

            btn2.BackColor = Color.FromArgb(120, 150, 90);
            btn2.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.FlatAppearance.BorderSize = 0;
            btn2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn2.Cursor = Cursors.Hand;

            btnSalir.BackColor = Color.FromArgb(170, 60, 60);
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSalir.Cursor = Cursors.Hand;

            btn2.MouseEnter += (s, e) =>
            {
                btn2.BackColor = Color.FromArgb(100, 130, 75);
            };

            btn2.MouseLeave += (s, e) =>
            {
                btn2.BackColor = Color.FromArgb(120, 150, 90);
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
    }
}