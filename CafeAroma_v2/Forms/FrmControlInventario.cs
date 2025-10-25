using CafeAroma_v2.Clases.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace CafeAroma_v2.Forms
{
    public partial class FrmControlInventario : Form
    {
        public FrmControlInventario()
        {
            InitializeComponent();
        }

        private void FrmControlInventario_Load(object sender, EventArgs e)
        {
            AplicarEstiloGrid(dgvStock);
            cboFiltro.Items.AddRange(new object[] { "Todos", "Arábica", "Robusta", "Blends" });
            cboFiltro.SelectedIndex = 0;
            Cargar();
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

        private void Cargar()
        {
            var dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_granos", new Dictionary<string, object>());
            string filtro = cboFiltro.Text;
            if (filtro != "Todos")
            {
                var rows = dt.Select($"tipo = '{filtro}'");

                if (rows.Length > 0)
                {
                    // Convierte el arreglo DataRow[] a un DataTable manualmente
                    DataTable dtFiltrado = dt.Clone(); // copia estructura
                    foreach (var row in rows)
                        dtFiltrado.ImportRow(row);

                    dt = dtFiltrado;
                }
                else
                {
                    dt = dt.Clone(); // devuelve una tabla vacía si no hay resultados
                }


            }
            dgvStock.DataSource = dt;

            // colorear por stock
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                int stock = 0;
                int.TryParse(Convert.ToString(row.Cells["stock"].Value), out stock);
                if (stock < 20) row.DefaultCellStyle.BackColor = Color.FromArgb(90, 40, 40);        // bajo
                else if (stock <= 50) row.DefaultCellStyle.BackColor = Color.FromArgb(90, 80, 40);  // medio
                else row.DefaultCellStyle.BackColor = Color.FromArgb(40, 90, 60);                   // alto
            }
        }

      
     

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cboFiltro_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
