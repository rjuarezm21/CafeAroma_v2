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
    public partial class FrmProduccion_Control : Form
    {
        public FrmProduccion_Control()
        {
            InitializeComponent();
        }

        private void FrmProduccion_Control_Load(object sender, EventArgs e)
        {
            CargarProcesos();
            comboEstado.Items.AddRange(new string[] { "Pendiente", "En Proceso", "Completado", "Cancelado" });
        }
        private void CargarProcesos()
        {
            try
            {
                listProcesos.Items.Clear();
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_procesos", parametros);

                foreach (DataRow row in dt.Rows)
                {
                    listProcesos.Items.Add($"{row["id_proceso"]} | {row["nombre"]} | Estado: {row["estado"]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdProceso.Text, out int id) || comboEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese ID y estado válido.");
                    return;
                }

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_proceso", id },
                    { "p_nuevo_estado", comboEstado.Text }
                };

                ConexionBD.Instancia.EjecutarSP("sp_actualizar_estado_proceso", parametros);

                MessageBox.Show("Estado actualizado correctamente.");
                CargarProcesos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
    
}
