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
    public partial class FrmMonitoreo : Form
    {
        public FrmMonitoreo()
        {
            InitializeComponent();
        }

        private void FrmMonitoreo_Load(object sender, EventArgs e)
        {
            CargarEntregas();
        }
        private void CargarEntregas()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_pedidos_completos", parametros);

                gridMonitoreo.DataSource = dt;
                gridMonitoreo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entregas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdPedido.Text))
                {
                    MessageBox.Show("Ingrese el ID del pedido a confirmar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPedido = int.Parse(txtIdPedido.Text);

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_pedido", idPedido },
                    { "p_nuevo_estado", "Entregado" },
                    { "p_fecha_entrega", DateTime.Now },
                    { "p_confirmado_recepcion", 1 }
                };

                ConexionBD.Instancia.EjecutarSP("sp_actualizar_estado_pedido", parametros);

                MessageBox.Show("✅ Recepción confirmada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEntregas();
                txtIdPedido.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar recepción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarEntregas();
            MessageBox.Show("🔄 Lista de entregas actualizada.",
                "Refrescar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
