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
    public partial class FrmOrdenCompra : Form
    {
        public FrmOrdenCompra()
        {
            InitializeComponent();
        }

             private void FrmOrdenCompra_Load_1(object sender, EventArgs e)
        {

            CargarGranos();
            CargarOrdenes();
        }
        private void CargarGranos()
        {
            try
            {
                var parametros = new Dictionary<string, object>(); // sin parámetros de entrada
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", parametros);

                // Combo de orden manual
                comboManualGrano.DataSource = dt;
                comboManualGrano.DisplayMember = "tipo";
                comboManualGrano.ValueMember = "id_grano";
                comboManualGrano.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error al cargar granos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarOrdenes()
        {
            try
            {
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_ordenes_compra", new Dictionary<string, object>());
                dgvOrdenes.DataSource = dt;

                // Ajustar columnas visualmente
                dgvOrdenes.Columns["id_orden"].HeaderText = "ID";
                dgvOrdenes.Columns["grano"].HeaderText = "Tipo de grano";
                dgvOrdenes.Columns["cantidad"].HeaderText = "Cantidad";
                dgvOrdenes.Columns["estado"].HeaderText = "Estado";
                dgvOrdenes.Columns["fecha_solicitud"].HeaderText = "Fecha solicitud";

                dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error al cargar órdenes de compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGenerarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                int umbral = (int)numUmbral.Value;      // valor de umbral (ej. 20)
                int cantidadReponer = (int)numReponer.Value;  // cantidad a reponer (ej. 50)

                if (umbral <= 0 || cantidadReponer <= 0)
                {
                    MessageBox.Show("Ingrese valores válidos para el umbral y cantidad a reponer.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Obtener todos los granos desde la BD
                var parametros = new Dictionary<string, object>();
                DataTable dtGranos = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", parametros);

                int ordenesCreadas = 0;

                foreach (DataRow row in dtGranos.Rows)
                {
                    int idGrano = Convert.ToInt32(row["id_grano"]);
                    string tipo = row["tipo"].ToString();
                    int stockActual = Convert.ToInt32(row["stock"]);

                    // 🔸 Si el stock es menor al umbral, generar una orden nueva
                    if (stockActual < umbral)
                    {
                        var p = new Dictionary<string, object>
                {
                    { "p_id_grano", idGrano },
                    { "p_cantidad", cantidadReponer }
                };

                        ConexionBD.Instancia.EjecutarSP("sp_generar_orden_compra", p);
                        ordenesCreadas++;
                    }
                }

                if (ordenesCreadas > 0)
                {
                    MessageBox.Show($"✅ Se generaron automáticamente {ordenesCreadas} órdenes de compra.",
                        "Órdenes generadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se detectaron granos por debajo del umbral establecido.",
                        "Sin órdenes generadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 🔄 Refrescar lista de órdenes
                CargarOrdenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar órdenes automáticas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarManual_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboManualGrano.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de grano.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idGrano = Convert.ToInt32(comboManualGrano.SelectedValue);
                int cantidad = Convert.ToInt32(numManualCantidad.Value);

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_grano", idGrano },
                    { "p_cantidad", cantidad }
                };

                ConexionBD.Instancia.EjecutarSP("sp_generar_orden_compra", parametros);

                MessageBox.Show("✅ Orden de compra registrada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarOrdenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la orden manual: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }
    }
}
