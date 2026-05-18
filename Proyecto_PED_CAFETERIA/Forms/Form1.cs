using Proyecto_PED_CAFETERIA.Clases;
using Proyecto_PED_CAFETERIA.Forms;
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

namespace Proyecto_PED_CAFETERIA
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
          
        }
        private void EstiloLabel(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(92, 64, 51);
        }
        private void DiseñarBotonLogin(Button btn, Color color, string texto)
        {
            btn.Text = texto;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Size = new Size(110, 40);
            RedondearControl(btn, 12);
        }
        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmVistaUsuario regresar = new FrmVistaUsuario();
            this.Hide();
            regresar.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ValidarAdministrador();
        }
        private void ValidarAdministrador()
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (usuario == "admin" && contrasena == "1234")
            {
                SesionActual.Usuario = "Administrador";
                SesionActual.Rol = "admin";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContrasena.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContrasena_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarAdministrador();
                e.SuppressKeyPress = true;
            }
        }
    }
}
