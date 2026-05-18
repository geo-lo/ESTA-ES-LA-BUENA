using CAFETERIA.ClasesNuevas;
using Proyecto_PED_CAFETERIA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class Inventario : Form
    {
        // Evento que avisa al FrmPedirOrden que hubo cambios en los productos
        public event EventHandler ProductosModificados;

        private void NotificarCambios()
        {
            ProductosModificados?.Invoke(this, EventArgs.Empty);
        }

        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            AplicarEstiloInventario();
            dgvInventario.DataSource = new ConsultasDB().MostrarInventario();
        }

        private void AplicarEstiloInventario()
        {
            // FORMULARIO
            this.BackColor = Color.FromArgb(250, 244, 236); // crema
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Inventario";

            // DATAGRIDVIEW
            dgvInventario.BackgroundColor = Color.White;
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.MultiSelect = false;
            dgvInventario.ReadOnly = true;



            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 72, 40);
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvInventario.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.ColumnHeadersHeight = 38;

            dgvInventario.DefaultCellStyle.BackColor = Color.White;
            dgvInventario.DefaultCellStyle.ForeColor = Color.FromArgb(70, 45, 30);
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvInventario.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 200, 170);
            dgvInventario.DefaultCellStyle.SelectionForeColor = Color.FromArgb(70, 45, 30);

            dgvInventario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 248, 243);
            dgvInventario.GridColor = Color.FromArgb(230, 220, 210);
            dgvInventario.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // TEXTBOXES
            EstiloTextBox(txtId);
            EstiloTextBox(txtNombre);
            EstiloTextBox(txtCantidad);
            EstiloTextBox(txtPrecio);

            // BOTONES
            EstiloBoton(btnBuscar, Color.FromArgb(120, 72, 40));   // café
            EstiloBoton(btnAgregar, Color.FromArgb(120, 150, 90)); // verde
            EstiloBoton(btnEliminar, Color.FromArgb(170, 60, 60)); // rojo
        }

        private void EstiloTextBox(TextBox txt)
        {
            txt.BackColor = Color.White;
            txt.ForeColor = Color.FromArgb(70, 45, 30);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void EstiloBoton(Button btn, Color colorBase)
        {
            btn.BackColor = colorBase;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Dark(colorBase);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = colorBase;
            };
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Acciones del boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConsultasDB repo = new ConsultasDB();

            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
                return;
            }

            if (id <= 0)
            {
                MessageBox.Show("El id debe ser un número positivo.");
                return;
            }

            DataTable resultado = repo.BuscarPorId(id);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];
                txtNombre.Text = fila["NombreProducto"].ToString();
                txtCantidad.Text = fila["CantidadActual"].ToString();
                txtPrecio.Text = fila["PrecioUnitario"].ToString();
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
        }

        // Acciones del boton agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btn = true;
            if (modificar == null || modificar.IsDisposed)
            {
                modificar = new frmModificarProducto();
                modificar.Show();
                modificar.refrescar += () =>
                {
                    RefrescarInventario();
                    NotificarCambios(); // Avisa al form principal
                };
            }
            else
            {
                modificar.BringToFront();
            }
        }

        // funcion para refrescar el datagridview con los datos de la tabla Inventario
        public void RefrescarInventario()
        {
            ConsultasDB repo = new ConsultasDB();
            dgvInventario.DataSource = repo.MostrarInventario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConsultasDB repo = new ConsultasDB();

            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
                return;
            }

            if (id <= 0)
            {
                MessageBox.Show("El id debe ser un número positivo.");
                return;
            }

            //Borrar producto de la BD
            repo.EliminarProducto(id);

            // Borrar imagen de la carpeta
            string carpeta = Path.Combine(Application.StartupPath, "Imagenes");

            if (Directory.Exists(carpeta))
            {
                // buscar cualquier extensión posible
                string[] extensiones = { ".png", ".jpg", ".jpeg", ".bmp" };

                foreach (string ext in extensiones)
                {
                    string ruta = Path.Combine(carpeta, id + ext);

                    if (File.Exists(ruta))
                    {
                        File.Delete(ruta);
                        break; // ya encontró y borró
                    }
                }
            }

            RefrescarInventario();
            NotificarCambios();

            MessageBox.Show("Producto e imagen eliminados correctamente.");
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Digite un ID.");
                return;
            }

            // Validación extra: Verificar si existe antes de abrir el form de edición
            ConsultasDB repo = new ConsultasDB();
            if (int.TryParse(txtId.Text, out int id))
            {
                DataTable info = repo.BuscarPorId(id);
                if (info.Rows.Count == 0)
                {
                    MessageBox.Show("El ID digitado no existe en el sistema.");
                    return; // Bloqueamos la apertura del formulario
                }
            }

            // Si pasó la validación, abrimos el form como ya sabías
            if (modificar == null || modificar.IsDisposed)
            {
                modificar = new frmModificarProducto();
                modificar.idRecibido = txtId.Text;
                modificar.refrescar += () =>
                {
                    RefrescarInventario();
                    NotificarCambios(); // Avisa al form principal
                };
                modificar.Show();
            }
            else
            {
                modificar.idRecibido = txtId.Text;
                modificar.BringToFront();
            }

        }

        frmModificarProducto modificar = null; //variable para controlar si ya existe el frm de modificar producto abierto
        public bool btn; // Agregar= True, Modificar= False sirve para verificar si el formulario de modificar producto se abrió para agregar un nuevo producto o para modificar uno existente

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}