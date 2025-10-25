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
    public partial class FrmEntregas : Form
    {
        public FrmEntregas()
        {
            InitializeComponent();
        }

        private void FrmEntregas_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }
        private void CargarPedidos()
        {
            var parametros = new Dictionary<string, object>();
            DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_pedidos_completos", parametros);
            gridPedidos.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = int.Parse(txtIdPedido.Text);
                string estado = comboEstado.Text;
                DateTime fechaEntrega = dateEntrega.Value;

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_pedido", idPedido },
                    { "p_nuevo_estado", estado },
                    { "p_fecha_entrega", fechaEntrega },
                    { "p_confirmado_recepcion", 0 }
                };

                ConexionBD.Instancia.EjecutarSP("sp_actualizar_estado_pedido", parametros);
                MessageBox.Show("Estado actualizado correctamente.");
                CargarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    
    }
}
