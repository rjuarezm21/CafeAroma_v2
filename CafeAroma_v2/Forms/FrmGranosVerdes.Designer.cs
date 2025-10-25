using System.Drawing;
using System.Windows.Forms;

namespace CafeAroma_v2.Forms
{
    partial class FrmGranosVerdes
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox grpListado;
        private DataGridView dgvGranos;
        private GroupBox grpRegistro;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblOrigen;
        private TextBox txtOrigen;
        private Label lblProv;
        private ComboBox cboProveedor;
        private Button btnGuardar;
        private Button btnRefrescar;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpListado = new System.Windows.Forms.GroupBox();
            this.dgvGranos = new System.Windows.Forms.DataGridView();
            this.grpRegistro = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.lblProv = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGranos)).BeginInit();
            this.grpRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpListado
            // 
            this.grpListado.Controls.Add(this.dgvGranos);
            this.grpListado.ForeColor = System.Drawing.Color.White;
            this.grpListado.Location = new System.Drawing.Point(16, 16);
            this.grpListado.Name = "grpListado";
            this.grpListado.Size = new System.Drawing.Size(860, 260);
            this.grpListado.TabIndex = 0;
            this.grpListado.TabStop = false;
            this.grpListado.Text = "Granos registrados";
            // 
            // dgvGranos
            // 
            this.dgvGranos.ColumnHeadersHeight = 29;
            this.dgvGranos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGranos.Location = new System.Drawing.Point(3, 18);
            this.dgvGranos.Name = "dgvGranos";
            this.dgvGranos.RowHeadersWidth = 51;
            this.dgvGranos.Size = new System.Drawing.Size(854, 239);
            this.dgvGranos.TabIndex = 0;
            // 
            // grpRegistro
            // 
            this.grpRegistro.Controls.Add(this.lblTipo);
            this.grpRegistro.Controls.Add(this.cboTipo);
            this.grpRegistro.Controls.Add(this.lblCantidad);
            this.grpRegistro.Controls.Add(this.txtCantidad);
            this.grpRegistro.Controls.Add(this.lblOrigen);
            this.grpRegistro.Controls.Add(this.txtOrigen);
            this.grpRegistro.Controls.Add(this.lblProv);
            this.grpRegistro.Controls.Add(this.cboProveedor);
            this.grpRegistro.Controls.Add(this.btnRefrescar);
            this.grpRegistro.Controls.Add(this.btnGuardar);
            this.grpRegistro.Controls.Add(this.lblInfo);
            this.grpRegistro.ForeColor = System.Drawing.Color.White;
            this.grpRegistro.Location = new System.Drawing.Point(16, 286);
            this.grpRegistro.Name = "grpRegistro";
            this.grpRegistro.Size = new System.Drawing.Size(860, 160);
            this.grpRegistro.TabIndex = 1;
            this.grpRegistro.TabStop = false;
            this.grpRegistro.Text = "Registro / actualización";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(20, 35);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Location = new System.Drawing.Point(117, 34);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(160, 24);
            this.cboTipo.TabIndex = 1;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(304, 30);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(100, 23);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(410, 27);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 3;
            // 
            // lblOrigen
            // 
            this.lblOrigen.Location = new System.Drawing.Point(537, 30);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(100, 23);
            this.lblOrigen.TabIndex = 4;
            this.lblOrigen.Text = "Origen:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(643, 31);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(160, 22);
            this.txtOrigen.TabIndex = 5;
            // 
            // lblProv
            // 
            this.lblProv.Location = new System.Drawing.Point(20, 75);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(100, 23);
            this.lblProv.TabIndex = 6;
            this.lblProv.Text = "Proveedor:";
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Location = new System.Drawing.Point(151, 72);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(260, 24);
            this.cboProveedor.TabIndex = 7;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.DimGray;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(600, 110);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 8;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(700, 110);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblInfo.Location = new System.Drawing.Point(20, 120);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 10;
            // 
            // FrmGranosVerdes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(892, 462);
            this.Controls.Add(this.grpListado);
            this.Controls.Add(this.grpRegistro);
            this.Name = "FrmGranosVerdes";
            this.Text = "Registro de granos verdes";
            this.Load += new System.EventHandler(this.FrmGranosVerdes_Load);
            this.grpListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGranos)).EndInit();
            this.grpRegistro.ResumeLayout(false);
            this.grpRegistro.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
