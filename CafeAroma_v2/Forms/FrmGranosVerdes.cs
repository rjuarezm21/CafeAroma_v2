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
    public partial class FrmGranosVerdes : Form
    {
        public FrmGranosVerdes()
        {
            InitializeComponent();
        }

        private void FrmGranosVerdes_Load(object sender, EventArgs e)
        {
            AplicarEstiloGrid(dgvGranos);
            CargarTiposDeGrano();
            CargarProveedores();
            CargarGranos();
        }
        private void AplicarEstiloGrid(DataGridView g)
        {
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.BackgroundColor = Color.FromArgb(35, 35, 35);
            g.BorderStyle = BorderStyle.None;
            g.RowHeadersVisible = false;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            g.DefaultCellStyle.ForeColor = Color.White;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 70, 20);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            g.GridColor = Color.FromArgb(70, 50, 30);
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // --------- Data loads ----------
        private void CargarTiposDeGrano()
        {
            try
            {
                var dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_tipos_grano", new Dictionary<string, object>());
                if (dt.Rows.Count > 0)
                {
                    cboTipo.DataSource = dt;
                    cboTipo.DisplayMember = "nombre";
                    cboTipo.ValueMember = "id_tipo_grano";
                }
                else
                {
                    // fallback por si no existe la tabla de tipos
                    cboTipo.Items.Clear();
                    cboTipo.Items.AddRange(new object[] { "Arábica", "Robusta", "Blends" });
                }
                cboTipo.SelectedIndex = 0;
            }
            catch
            {
                cboTipo.Items.Clear();
                cboTipo.Items.AddRange(new object[] { "Arábica", "Robusta", "Blends" });
                cboTipo.SelectedIndex = 0;
            }
        }

        private void CargarProveedores()
        {
            try
            {
                var dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_proveedores", new Dictionary<string, object>());
                cboProveedor.DataSource = dt;
                cboProveedor.DisplayMember = "nombre";
                cboProveedor.ValueMember = "id_proveedor";
                cboProveedor.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
            catch { /* opcional: mostrar aviso */ }
        }

        private void CargarGranos()
        {
            try
            {
                var dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", new Dictionary<string, object>());
                dgvGranos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar granos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                var parametros = new Dictionary<string, object>
                {
                    { "p_tipo", cboTipo.Text },
                    { "p_origen", txtOrigen.Text.Trim() },
                    { "p_stock", cantidad }
                };

                ConexionBD.Instancia.EjecutarSP("sp_insertar_grano", parametros);
                lblInfo.Text = "✅ Grano registrado/actualizado.";
                CargarGranos();
                txtOrigen.Clear();
                txtCantidad.Clear();
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarGranos();
            lblInfo.Text = "🔄 Lista refrescada.";
        }
    }
}
