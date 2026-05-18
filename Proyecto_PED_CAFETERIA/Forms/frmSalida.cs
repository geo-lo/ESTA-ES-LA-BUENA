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
    public partial class frmSalida : Form
    {
        public frmSalida()
        {
            InitializeComponent();
        }

        private void frmSalida_Load(object sender, EventArgs e)
        {
            // 1. Tamaño y Posición del Formulario
            this.Size = new Size(550, 300); // Un poco más grande para que respire el diseño
            this.StartPosition = FormStartPosition.CenterScreen; // CENTRADO AUTOMÁTICO EN PANTALLA
            this.BackColor = Color.FromArgb(250, 244, 236);
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Centrar el Texto (lblS)
            lblS.AutoSize = false;
            lblS.Size = new Size(this.Width - 40, 50); // Ocupa casi todo el ancho
                                                       // Posición: (Mitad del form - Mitad del label)
            lblS.Location = new Point((this.Width - lblS.Width) / 2, 60);
            lblS.TextAlign = ContentAlignment.MiddleCenter;
            lblS.Text = "¿ESTÁ SEGURO QUE DESEA SALIR DEL SISTEMA?";
            lblS.ForeColor = Color.FromArgb(92, 64, 51);
            lblS.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // 3. Centrar los Botones
            // Calculamos el centro para que ambos botones queden alineados al medio
            int botonesY = 160;
            int espacioEntreBotones = 20;

            btnSalir.Size = new Size(150, 50);
            btnNo.Size = new Size(150, 50);

            // Botón Salir (A la izquierda del centro)
            btnSalir.Location = new Point((this.Width / 2) - btnSalir.Width - (espacioEntreBotones / 2), botonesY);

            // Botón Cancelar (A la derecha del centro)
            btnNo.Location = new Point((this.Width / 2) + (espacioEntreBotones / 2), botonesY);

            // Aplicar estilos
            DiseñarBotonSalir(btnSalir, Color.FromArgb(170, 68, 68), "SÍ, SALIR");
            DiseñarBotonSalir(btnNo, Color.FromArgb(120, 72, 40), "CANCELAR");

            // Redondear todo
            RedondearControl(this, 30);
        }
        private void DiseñarBotonSalir(Button btn, Color color, string texto)
        {
            btn.Text = texto;
            btn.Size = new Size(130, 45);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            RedondearControl(btn, 15);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Mensaje de despedida personalizado con el nombre de tu cafetería
            MessageBox.Show("Gracias por usar el sistema de Dulce Aroma. ¡Feliz jornada!", "Cerrando Sesión");
            Application.Exit();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            FrmVistaUsuario regresar = new FrmVistaUsuario();
            regresar.ShowDialog();
        }
    }
}
