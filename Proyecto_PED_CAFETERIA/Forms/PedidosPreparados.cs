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
    public partial class PedidosPreparados : Form
    {
        public static PedidosPreparados instancia;
        public PedidosPreparados()
        {
            InitializeComponent();
        }

        private void PedidosPreparados_Load(object sender, EventArgs e)
        {
            AplicarEstiloPreparados();

            ConsultasDB repo = new ConsultasDB();
            dgvPreparados.DataSource = repo.MostrarHistorialVentas();
            //CargarPedidos();
        }

        private void AplicarEstiloPreparados()
        {
            // FORMULARIO
            this.BackColor = Color.FromArgb(250, 244, 236);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Pedidos Preparados";

            // TITULO
            label1.Text = "PEDIDOS PREPARADOS";
            label1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(92, 64, 51);
            label1.BackColor = Color.Transparent;
            label1.AutoSize = true;

           

            // DATAGRIDVIEW
            dgvPreparados.BackgroundColor = Color.White;
            dgvPreparados.BorderStyle = BorderStyle.None;
            dgvPreparados.EnableHeadersVisualStyles = false;
            dgvPreparados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPreparados.RowHeadersVisible = false;
            dgvPreparados.AllowUserToAddRows = false;
            dgvPreparados.AllowUserToDeleteRows = false;
            dgvPreparados.AllowUserToResizeRows = false;
            dgvPreparados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreparados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPreparados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreparados.MultiSelect = false;
            dgvPreparados.ReadOnly = true;

            dgvPreparados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 72, 40);
            dgvPreparados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPreparados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvPreparados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPreparados.ColumnHeadersHeight = 38;

            dgvPreparados.DefaultCellStyle.BackColor = Color.White;
            dgvPreparados.DefaultCellStyle.ForeColor = Color.FromArgb(70, 45, 30);
            dgvPreparados.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPreparados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 200, 170);
            dgvPreparados.DefaultCellStyle.SelectionForeColor = Color.FromArgb(70, 45, 30);

            dgvPreparados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 248, 243);
            dgvPreparados.GridColor = Color.FromArgb(230, 220, 210);
            dgvPreparados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

         




        }
        

       

        private void dgvPreparados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        


        public void MostrarPreparados()
        {
            dgvPreparados.Rows.Clear();

            NodoHistorial actual = ClaseGlobal.historial.Primero;
            int contador = 0;

            while (actual != null)
            {
                dgvPreparados.Rows.Add(actual.Cliente, actual.Productos, actual.Total);
                actual = actual.siguiente;
                contador++;
            }

        }

    }
    }
