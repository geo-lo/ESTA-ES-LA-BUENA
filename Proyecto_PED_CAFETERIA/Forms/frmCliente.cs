using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class frmCliente : Form
    {
        public string NombreCliente {  get; private set; }
        public frmCliente()
        {
            InitializeComponent();
            // Quitar el borde del formulario para un look más moderno
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        // MÉTODO PARA REDONDEAR CONTROLES (Igual al que usas en PedirOrden)
        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(control.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(control.Width - radio, control.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radio, radio, radio), 90, 90);

            path.CloseFigure();

            control.Region = new Region(path);
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un Nombre");
                txtNombre.Focus();
                return;
            }
            NombreCliente = txtNombre.Text;
            NombreCliente.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarNombre();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un Nombre");
                return;
            }
            NombreCliente = txtNombre.Text;
            NombreCliente.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            // =========================
            // FORMULARIO
            // =========================
            this.Size = new Size(650, 380);
            this.BackColor = Color.FromArgb(250, 244, 236);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // =========================
            // PANEL CONTENEDOR
            // =========================
            Panel panel = new Panel();
            panel.Size = new Size(620, 340);
            panel.Location = new Point(15, 15);
            panel.BackColor = Color.White;
            this.Controls.Add(panel);

            RedondearControl(panel, 30);

            // =========================
            // BOTÓN CERRAR
            // =========================
            Button btnCerrar = new Button();
            btnCerrar.Text = "✕";
            btnCerrar.Size = new Size(40, 40);
            btnCerrar.Location = new Point(560, 10);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.ForeColor = Color.SaddleBrown;
            btnCerrar.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;

            btnCerrar.Click += (s, ev) =>
            {
                this.Close();
            };

            panel.Controls.Add(btnCerrar);

            // =========================
            // IMAGEN CLIENTE
            // =========================
            pictureBox1.Size = new Size(170, 170);
            pictureBox1.Location = new Point(25, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.Transparent;

            panel.Controls.Add(pictureBox1);

            // =========================
            // TÍTULO
            // =========================
            Label lblTitulo = new Label();
            lblTitulo.Text = "CLIENTE";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(92, 64, 51);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(240, 50);

            panel.Controls.Add(lblTitulo);

            // =========================
            // LABEL NOMBRE
            // =========================
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre";
            lblNombre.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblNombre.ForeColor = Color.SaddleBrown;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(245, 105);

            panel.Controls.Add(lblNombre);

            // =========================
            // TEXTBOX
            // =========================
            txtNombre.Parent = panel;
            txtNombre.Size = new Size(300, 40);
            txtNombre.Location = new Point(245, 130);
            txtNombre.Font = new Font("Segoe UI", 13);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.ForeColor = Color.SaddleBrown;
            txtNombre.BackColor = Color.FromArgb(250, 248, 245);

            // =========================
            // DESCRIPCIÓN
            // =========================
            Label lblDescripcion = new Label();

            lblDescripcion.Text = "Ingresa el nombre del cliente para identificar correctamente el pedido y brindar una atención personalizada.";

            lblDescripcion.Location = new Point(245, 180);

            lblDescripcion.Size = new Size(320, 70);

            lblDescripcion.ForeColor = Color.Gray;

            lblDescripcion.Font = new Font("Segoe UI", 10);

            lblDescripcion.BackColor = Color.Transparent;

            panel.Controls.Add(lblDescripcion);

            // =========================
            // BOTÓN ACEPTAR
            // =========================
            btnAceptar.Parent = panel;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.Size = new Size(180, 50);
            btnAceptar.Location = new Point(365, 255);

            btnAceptar.BackColor = Color.FromArgb(111, 78, 55);
            btnAceptar.ForeColor = Color.White;

            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderSize = 0;

            btnAceptar.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnAceptar.Cursor = Cursors.Hand;

            RedondearControl(btnAceptar, 20);

            txtNombre.Focus();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                ValidarNombre();
            }
        }

        private void frmCliente_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
    }
}
