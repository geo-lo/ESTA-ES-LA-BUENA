using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Proyecto_PED_CAFETERIA.Forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // 1. Limpiar series y áreas predeterminadas
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // 2. Crear y añadir una nueva área de gráfico
            ChartArea areaPrincipal = new ChartArea("AreaPastel");
            chart1.ChartAreas.Add(areaPrincipal);

            // 3. Crear la serie y definirla como gráfico de pastel (Pie)
            Series seriePastel = new Series("Ventas")
            {
                ChartType = SeriesChartType.Pie // Aquí se asigna el gráfico circular
            };
            chart1.Series.Add(seriePastel);

            // 4. Agregar los datos (Categoría, Valor)
            seriePastel.Points.AddXY("Producto A", 450);
            seriePastel.Points.AddXY("Producto B", 300);
            seriePastel.Points.AddXY("Producto C", 150);
            seriePastel.Points.AddXY("Producto D", 100);

            // 5. Configurar etiquetas para mostrar los valores o porcentajes
            chart1.Series["Ventas"].IsValueShownAsLabel = true;

            // Opcional: Si quieres mostrar porcentajes en lugar de los valores numéricos directos
            // chart1.Series["Ventas"].Label = "#PERCENT{P0}";


            // --- CONFIGURACIÓN GRÁFICO 1: BARRAS ---
            chartBarras.Series.Clear();
            Series serieBarras = new Series("Ventas")
            {
                ChartType = SeriesChartType.Column // Barras verticales
            };
            chartBarras.Series.Add(serieBarras);

            // Datos de ejemplo
            serieBarras.Points.AddXY("Ene", 500);
            serieBarras.Points.AddXY("Feb", 800);
            serieBarras.Points.AddXY("Mar", 400);
        }
    }
}
