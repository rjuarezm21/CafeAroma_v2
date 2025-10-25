using CafeAroma_v2.Clases.Entidades; // Agregar el namespace de la clase Lote
using CafeAroma_v2.Clases.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CafeAroma_v2.Forms
{
    public partial class FrmLotes : Form
    {
        public FrmLotes()
        {
            InitializeComponent();
        }

        private void FrmLotes_Load(object sender, EventArgs e)
        {
            CargarLotes();
        }

        private void CargarLotes()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_lotes", parametros);

                // Convertimos las filas del DataTable a una lista de objetos Lote
                var lotes = new List<Lote>();
                foreach (DataRow row in dt.Rows)
                {
                    var lote = new Lote(
                        Convert.ToInt32(row["id_lote"]),
                        row["numero_lote"].ToString(),
                        row["estado"].ToString(),
                        Convert.ToDateTime(row["fecha_vencimiento"])
                    );
                    lotes.Add(lote);
                }

                // Asignamos la lista de lotes al DataGridView
                gridLotes.DataSource = lotes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los lotes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumeroLote.Text))
                {
                    MessageBox.Show("Ingrese un número de lote.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un objeto Lote con los valores del formulario
                var nuevoLote = new Lote(0, txtNumeroLote.Text.Trim(), comboEstado.Text, dateVencimiento.Value);

                var parametros = new Dictionary<string, object>
                {
                    { "p_numero_lote", nuevoLote.NumeroLote },
                    { "p_estado", nuevoLote.Estado },
                    { "p_fecha_vencimiento", nuevoLote.FechaVencimiento }
                };

                ConexionBD.Instancia.EjecutarSP("sp_insertar_lote", parametros);
                MessageBox.Show("✅ Lote registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el lote: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdLote.Text))
                {
                    MessageBox.Show("Seleccione un lote válido.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto Lote con los datos a actualizar
                var loteActualizar = new Lote(
                    Convert.ToInt32(txtIdLote.Text),
                    null, // El número de lote no se está actualizando
                    comboEstado.Text,
                    DateTime.MinValue // La fecha de vencimiento no se actualiza
                );

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_lote", loteActualizar.IdLote },
                    { "p_estado", loteActualizar.Estado }
                };

                ConexionBD.Instancia.EjecutarSP("sp_actualizar_estado_lote", parametros);
                MessageBox.Show("Estado actualizado correctamente.");
                CargarLotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el lote: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtIdLote.Clear();
            txtNumeroLote.Clear();
            comboEstado.SelectedIndex = 0;
            dateVencimiento.Value = DateTime.Today.AddMonths(6);
        }

        private void gridLotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener los datos del lote seleccionado y mostrar en los campos del formulario
                var loteSeleccionado = (Lote)gridLotes.Rows[e.RowIndex].DataBoundItem;

                txtIdLote.Text = loteSeleccionado.IdLote.ToString();
                txtNumeroLote.Text = loteSeleccionado.NumeroLote;
                comboEstado.Text = loteSeleccionado.Estado;
                dateVencimiento.Value = loteSeleccionado.FechaVencimiento;
            }
        }
    }
}
