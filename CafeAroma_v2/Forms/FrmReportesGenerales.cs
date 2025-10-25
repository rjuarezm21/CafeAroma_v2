using CafeAroma_v2.Clases.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeAroma_v2.Forms
{
    public partial class FrmReportesGenerales : Form
    {
        public FrmReportesGenerales()
        {
            InitializeComponent();
        }

        private void FrmReportesGenerales_Load(object sender, EventArgs e)
        {
            comboTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = comboTipoReporte.Text;
                DataTable dt = new DataTable();

                switch (tipo)
                {
                    case "Inventario":
                        dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", new Dictionary<string, object>());
                        break;
                    case "Producción":
                        dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_procesos", new Dictionary<string, object>());
                        break;
                    case "Pedidos":
                        dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_pedidos_completos", new Dictionary<string, object>());
                        break;
                    case "Lotes":
                        dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_lotes", new Dictionary<string, object>());
                        break;
                }

                gridReportes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando reporte: " + ex.Message);
            }
        }
    }
    
}
