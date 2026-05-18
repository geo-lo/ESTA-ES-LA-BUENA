using CAFETERIA.ClasesNuevas;
using Proyecto_PED_CAFETERIA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class FrmPedirOrden : Form
    {
        string nombreProducto;
        double precio;
        ListaProductos lista = new ListaProductos();

        public FrmPedirOrden()
        {
            InitializeComponent();
        }

        public FrmPedirOrden(string nombreProducto, double precio)
        {
            InitializeComponent();
            this.nombreProducto = nombreProducto;
            this.precio = precio;
        }

        // MÉTODO PARA REDONDEAR
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

        // MÉTODO PARA CREAR BOTONES DINÁMICOS DESDE LA BASE DE DATOS
        private void CrearBotonProducto(ListaProductos lista, TabPage pagina, string categoria)
        {
            pagina.Controls.Clear();
            pagina.AutoScroll = true;

            int columnas = 3;
            int anchoBtn = 230;
            int altoBtn = 275;
            int margen = 10;

            int i = 0;
            Nodo_ListaProductos actual = lista.Primero;

            while (actual != null)
            {
                Producto p = actual.ProductoGuardado;

                if (p.Categoria != categoria)
                {
                    actual = actual.siguiente;
                    continue;
                }

                Button btn = new Button();

                btn.Tag = p.Id;
                btn.Size = new Size(anchoBtn, altoBtn);

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 224, 192);

                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(70, 40, 10);

                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                string rutaImagen = Path.Combine(
                    Application.StartupPath,
                    "Imagenes",
                    $"{p.Id}.png"
                );

                if (File.Exists(rutaImagen))
                {
                    Image img = Image.FromFile(rutaImagen);

                    btn.Image = new Bitmap(img,btn.Size);

                    btn.ImageAlign = ContentAlignment.TopCenter;
                    
                    
                    btn.Padding = new Padding(5);
                }
                else
                {
                    // SI NO HAY IMAGEN
                    btn.Text = $"{p.NombreProducto}\n${p.Precio:F2}";
                }

              

                int fila = i / columnas;
                int columna = i % columnas;
                btn.Location = new Point(margen + columna * (anchoBtn + margen), margen + fila * (altoBtn + margen));

                // Captura local para el lambda
                Producto prod = p;
                btn.Click += (s, e) =>
                {
                    frmCantidad frm = new frmCantidad(
                        prod.NombreProducto,
                        prod.Precio,
                        prod.Descripcion
                    );
                    frm.idProducto = prod.Id;
                    estiloForm(frm);
                    frm.ShowDialog();
                };

                pagina.Controls.Add(btn);
                i++;
                actual = actual.siguiente;
            }
        }

        // CARGA PRODUCTOS DESDE LA BD Y RECONSTRUYE LOS BOTONES
        public void CargarProductosDesdeDB()
        {
            lista = new ListaProductos();

            ConsultasDB repo = new ConsultasDB();
            DataTable tabla = repo.MostrarInventario();

            foreach (DataRow fila in tabla.Rows)
            {
                int id           = Convert.ToInt32(fila["IdProducto"]);
                string nombre    = fila["NombreProducto"].ToString();
                double p         = Convert.ToDouble(fila["PrecioUnitario"]);
                string categoria = tabla.Columns.Contains("Categoria")   ? fila["Categoria"].ToString()   : "";
                string desc      = tabla.Columns.Contains("Descripcion") ? fila["Descripcion"].ToString() : "";
                string imagen = tabla.Columns.Contains("Imagen") ? fila["Imagen"].ToString() : "";

                Producto prod = new Producto(nombre, id, 1, p, null, categoria, desc, imagen);
                lista.AgregarProducto(prod);
            }

            // tablaC es el nombre del TabControl en el Designer
            string[] categorias = { "Comidas", "Bebidas", "Antojitos", "Mas" };
            for (int i = 0; i < tablaC.TabPages.Count && i < categorias.Length; i++)
            {
                CrearBotonProducto(lista, tablaC.TabPages[i], categorias[i]);
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductosDesdeDB();

            tablaC.DrawMode = TabDrawMode.OwnerDrawFixed;
            tablaC.DrawItem += tabProductos_DrawItem;

            RedondearControl(btnConfirmar, 20);
            RedondearControl(btnCarrito, 20);
            RedondearControl(btnNombre, 20);

            btnConfirmar.BackColor = Color.FromArgb(255, 240, 220);
            btnConfirmar.ForeColor = Color.SaddleBrown;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatAppearance.BorderSize = 0;

            btnCarrito.BackColor = Color.FromArgb(255, 240, 220);
            btnCarrito.FlatStyle = FlatStyle.Flat;
            btnCarrito.FlatAppearance.BorderSize = 0;

            btnNombre.BackColor = Color.FromArgb(255, 240, 220);
            btnNombre.ForeColor = Color.SaddleBrown;
            btnNombre.FlatStyle = FlatStyle.Flat;
            btnNombre.FlatAppearance.BorderSize = 0;
        }

        private void estiloForm(Form frm)
        {
            frm.BackColor = Color.FromArgb(255, 255, 255);
            frm.ForeColor = Color.FromArgb(0, 0, 0);
            frm.Font = new Font("Unispace", 8, FontStyle.Regular);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNombre.Text))
            {
                MessageBox.Show("Ingrese un Nombre", "AVISO");
                return;
            }
            if (ClaseGlobal.listaTemporal == null || ClaseGlobal.listaTemporal.Primero == null)
            {
                MessageBox.Show("Agregue al menos un producto", "AVISO");
                return;
            }

            string nombreCliente = lblNombre.Text;
            Pedido pedido = new Pedido(ClaseGlobal.listaTemporal, nombreCliente);
            ClaseGlobal.colaPedidos.Encolar(pedido);
            MessageBox.Show("Pedido en la cola", "EXITO");
            ClaseGlobal.listaTemporal = new ListaProductos();
            lblNombre.Text = "";
        }

        private void btnNombre_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            if (frm.ShowDialog() == DialogResult.OK)
                lblNombre.Text = frm.NombreCliente;
        }

        private void FrmPedirOrden_Shown(object sender, EventArgs e)
        {
            lblNombre.Focus();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (ClaseGlobal.listaTemporal.Primero == null)
            {
                MessageBox.Show("Agregue al menos un producto");
                return;
            }
            frmCarrito carrito = new frmCarrito();
            estiloForm(carrito);
            carrito.ShowDialog();
        }

        private void tabProductos_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            Graphics g = e.Graphics;
            TabPage pagina = tab.TabPages[e.Index];
            Rectangle area = tab.GetTabRect(e.Index);

            bool seleccionado = (e.Index == tab.SelectedIndex);
            Color fondo = seleccionado ? Color.FromArgb(95, 45, 15) : Color.White;
            Color texto = seleccionado ? Color.White : Color.SaddleBrown;

            using (SolidBrush brush = new SolidBrush(fondo))
                g.FillRectangle(brush, area);

            TextRenderer.DrawText(g, pagina.Text, tab.Font, area, texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ── Handlers vacíos requeridos por el Designer ───────────────────────
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage1_Click_1(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        
    }
}
