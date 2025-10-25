using CafeAroma_v2.Clases.Database;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace CafeAroma_v2.Forms
{
    public partial class FrmProduccion_Reportes : Form
    {
        public FrmProduccion_Reportes()
        {
            InitializeComponent();
        }

        private void FrmProduccion_Reportes_Load(object sender, EventArgs e)
        {
            CargarTotales();
        }
        private void CargarTotales()
        {
            var parametros = new Dictionary<string, object>();
            DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_procesos", parametros);

            int total = dt.Rows.Count;
            int completados = 0, pendientes = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["estado"].ToString() == "Completado") completados++;
                if (row["estado"].ToString() == "Pendiente") pendientes++;
            }

            lblTotal.Text = $"Total: {total}";
            lblCompletados.Text = $"Completados: {completados}";
            lblPendientes.Text = $"Pendientes: {pendientes}";
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            var parametros = new Dictionary<string, object>();
            DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_procesos", parametros);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Informe Producción");
                ws.Cell(1, 1).InsertTable(dt);
                ws.Columns().AdjustToContents();

                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Informe_Produccion.xlsx";
                wb.SaveAs(ruta);
                MessageBox.Show($" Informe generado en:\n{ruta}", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
