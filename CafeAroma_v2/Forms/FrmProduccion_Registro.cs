using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CafeAroma_v2.Clases.Database;

namespace CafeAroma_v2.Forms
{
    public partial class FrmProduccion_Registro : Form
    {
        public FrmProduccion_Registro()
        {
            InitializeComponent();
        }

        private void FrmProduccion_Registro_Load(object sender, EventArgs e)
        {
            CargarGranos();
            CargarEtapas();
            CargarProcesos();
        }

        private void CargarGranos()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", parametros);

                comboGrano.DataSource = dt;
                comboGrano.DisplayMember = "tipo";
                comboGrano.ValueMember = "id_grano";
                comboGrano.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar granos: " + ex.Message);
            }
        }

        private void CargarEtapas()
        {
            comboEtapa.Items.Clear();
            comboEtapa.Items.AddRange(new string[] { "Teñido", "Corte", "Confección", "Empaque", "Control de Calidad" });
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboGrano.SelectedIndex == -1 || comboEtapa.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione tipo de grano y etapa.");
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                string descripcion = txtDescripcion.Text.Trim();

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_grano", comboGrano.SelectedValue },
                    { "p_nombre", comboEtapa.Text },
                    { "p_descripcion", descripcion },
                    { "p_cantidad_usada", cantidad },
                    { "p_id_producto", DBNull.Value },
                    { "p_resultado", descripcion },
                };

                ConexionBD.Instancia.EjecutarSP("sp_insertar_proceso", parametros);

                MessageBox.Show("Proceso registrado correctamente.");
                CargarProcesos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                MessageBox.Show("Error al cargar procesos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            comboGrano.SelectedIndex = -1;
            comboEtapa.SelectedIndex = -1;
            txtCantidad.Clear();
            txtDescripcion.Clear();
        }
    }
}
