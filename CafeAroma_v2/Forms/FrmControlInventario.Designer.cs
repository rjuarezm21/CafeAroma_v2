using System.Drawing;
using System.Windows.Forms;

namespace CafeAroma_v2.Forms
{
    partial class FrmControlInventario
    {
        private GroupBox grp;
        private DataGridView dgvStock;
        private Label lblFiltro;
        private ComboBox cboFiltro;
        private Button btnRefrescar;

        private void InitializeComponent()
        {
            this.grp = new System.Windows.Forms.GroupBox();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.dgvStock);
            this.grp.ForeColor = System.Drawing.Color.White;
            this.grp.Location = new System.Drawing.Point(16, 56);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(860, 380);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            this.grp.Text = "Inventario por tipo de grano";
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeight = 29;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(3, 18);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.Size = new System.Drawing.Size(854, 359);
            this.dgvStock.TabIndex = 0;
            // 
            // lblFiltro
            // 
            this.lblFiltro.ForeColor = System.Drawing.Color.White;
            this.lblFiltro.Location = new System.Drawing.Point(20, 20);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(100, 23);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Filtro:";
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.Location = new System.Drawing.Point(126, 19);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(180, 24);
            this.cboFiltro.TabIndex = 2;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged_1);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.DimGray;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(349, 16);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click_1);
            // 
            // FrmControlInventario
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(892, 462);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.btnRefrescar);
            this.Name = "FrmControlInventario";
            this.Text = "Control de inventario";
            this.Load += new System.EventHandler(this.FrmControlInventario_Load);
            this.grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
