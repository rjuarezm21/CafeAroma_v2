using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CafeAroma_v2.Clases.Database;

namespace CafeAroma_v2.Forms
{
    public partial class FrmProductosTerminados : Form
    {
        public FrmProductosTerminados()
        {
            InitializeComponent();
        }

        private void FrmProductosTerminados_Load(object sender, EventArgs e)
        {
            CargarProcesosCompletados();
            CargarProductosTerminados();
        }

        // ===============================================================
        //  Cargar lista de granos desde la BD
        // ===============================================================
        private void CargarProcesosCompletados()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_procesos_completados", parametros);

                comboProceso.DataSource = dt;
                comboProceso.DisplayMember = "nombre";
                comboProceso.ValueMember = "id_proceso";
                comboProceso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar procesos: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboProceso.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un proceso completado.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLote.Text))
                {
                    MessageBox.Show("Ingrese un número de lote.");
                    return;
                }

                if (comboEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un estado del producto.");
                    return;
                }

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_proceso", Convert.ToInt32(comboProceso.SelectedValue) },
                    { "p_numero_lote", txtLote.Text },
                    { "p_estado", comboEstado.Text },
                    { "p_fecha_vencimiento", dateVencimiento.Value.Date }
                };

                ConexionBD.Instancia.EjecutarSP("sp_insertar_producto_terminado", parametros);
                MessageBox.Show("Producto terminado registrado correctamente.", "Registro exitoso");

                CargarProductosTerminados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
    
      private void CargarProductosTerminados()
        {
            try
            {
                listProductos.Items.Clear();
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_productos_terminados", parametros);

                foreach (DataRow row in dt.Rows)
                {
                    listProductos.Items.Add($"Lote #{row["numero_lote"]} | {row["proceso"]} | Estado: {row["estado"]} | Vence: {Convert.ToDateTime(row["fecha_vencimiento"]).ToShortDateString()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos terminados: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            comboProceso.SelectedIndex = -1;
            txtLote.Clear();
            comboEstado.SelectedIndex = -1;
            dateVencimiento.Value = DateTime.Now;
        }
    }
}
