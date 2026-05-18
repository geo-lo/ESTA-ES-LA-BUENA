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
    public partial class FrmHistorialPedidos : Form
    {
        public static FrmHistorialPedidos instancia;

        public FrmHistorialPedidos()
        {
            InitializeComponent();
            instancia = this;
        }

        public void AgregarHistorial(string cliente, string productos, string total)
        {

        }

        private void FrmHistorialPedidos_Load(object sender, EventArgs e)
        {
            // Fondo del formulario para que combine con el diseño
            this.BackColor = Color.FromArgb(250, 244, 236);

            ConfigurarGridHistorial();
            estiloDataGrid(dgvHistorial);

            dgvHistorial.MultiSelect = false;
            dgvHistorial.ReadOnly = true;

            MostrarPedidos();

            // =====================================
            // POSICIONAMIENTO Y DISEÑO DE BOTONES
            // =====================================
            int puntoY = dgvHistorial.Bottom + 20; // Se posicionan automáticamente debajo del grid
            int inicioX = dgvHistorial.Location.X;

            btnPreparar.Location = new Point(inicioX, puntoY);
            btnBorrar.Location = new Point(inicioX + 145, puntoY); // Separación de 15px (130 ancho + 15)

            // Aplicar colores de la imagen
            DiseñarBoton(btnPreparar, Color.FromArgb(107, 142, 85)); // Verde Procesar
            DiseñarBoton(btnBorrar, Color.FromArgb(170, 68, 68));   // Rojo Salir

            ConfigurarGridHistorial();
            // CargarHistorial();
            estiloDataGrid(dgvHistorial);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.ReadOnly = true;

            MostrarPedidos();
            estiloDataGrid(dgvHistorial);
            foreach (DataGridViewColumn col in dgvHistorial.Columns)
            {
                col.Frozen = false;
            }
        }
        private void DiseñarBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 45;
            btn.Width = 130;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            // Margen para asegurar separación si usas contenedores automáticos
            btn.Margin = new Padding(0, 0, 15, 0);
        }
        private void ConfigurarGridHistorial()
        {
            dgvHistorial.Columns.Clear();
            dgvHistorial.Rows.Clear();
            dgvHistorial.AutoGenerateColumns = false;

            dgvHistorial.Columns.Add("Cliente", "Cliente");
            dgvHistorial.Columns.Add("Productos", "Productos");
            dgvHistorial.Columns.Add("Total", "Total");

            foreach (DataGridViewColumn col in dgvHistorial.Columns)
            {
                col.Frozen = false;
            }
        }
        public void MostrarPedidos()
        {
            dgvHistorial.Rows.Clear();

            NodoHistorial actual = ClaseGlobal.historial.Primero;

            while (actual != null)
            {
                dgvHistorial.Rows.Add(
                    actual.Cliente,
                    actual.Productos,
                    actual.Total
                );

                actual = actual.siguiente;
            }

        }

        private void estiloDataGrid(DataGridView dataHistorial)
        {
            if (dataHistorial == null || dataHistorial.IsDisposed)
                return;

            foreach (DataGridViewColumn col in dataHistorial.Columns)
            {
                col.Frozen = false;
            }
            // ELIMINAR EL GRIS FEO Y CONFIGURAR FONDO
            dataHistorial.BackgroundColor = Color.FromArgb(250, 244, 236);
            dataHistorial.BorderStyle = BorderStyle.None;
            dataHistorial.GridColor = Color.FromArgb(210, 190, 170);

            // Ajustes de celdas
            dataHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Colores de filas
            dataHistorial.RowsDefaultCellStyle.BackColor = Color.White;
            dataHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 228, 217);
            dataHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(141, 102, 77);
            dataHistorial.DefaultCellStyle.SelectionForeColor = Color.White;

            // Encabezados (Header) estilo Café
            dataHistorial.EnableHeadersVisualStyles = false;
            dataHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(92, 64, 51);
            dataHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataHistorial.ColumnHeadersHeight = 45;

            dataHistorial.RowHeadersVisible = false;
            dataHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataHistorial.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataHistorial.BorderStyle = BorderStyle.None;
            dataHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 228, 217);
            dataHistorial.BackgroundColor = Color.FromArgb(230, 220, 205);
            dataHistorial.GridColor = Color.FromArgb(210, 190, 170);

            dataHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(141, 102, 77);
            dataHistorial.DefaultCellStyle.SelectionForeColor = Color.White;

            dataHistorial.EnableHeadersVisualStyles = false;
            dataHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(92, 64, 51);
            dataHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataHistorial.ColumnHeadersHeight = 38;

            dataHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataHistorial.DefaultCellStyle.ForeColor = Color.FromArgb(70, 45, 30);

            dataHistorial.RowHeadersVisible = false;
            dataHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataHistorial.MultiSelect = false;
            dataHistorial.ReadOnly = true;
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // ESTE BOTON MANDA EL PEDIDO A PREPARADOS
        private void btnPreparar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0) return;
            string cliente = dgvHistorial.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show("Pedido de " + cliente + " enviado a preparación.", "Preparación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay pedidos en el historial.", "Aviso");
                return;
            }

            dgvHistorial.Rows.RemoveAt(0);
            MessageBox.Show("Pedido preparado.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¿Desea eliminar este pedido?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvHistorial.Rows.RemoveAt(dgvHistorial.SelectedRows[0].Index);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

          
        }
     
    }
}