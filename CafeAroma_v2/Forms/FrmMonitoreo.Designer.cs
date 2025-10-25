using System.Windows.Forms;
using System.Drawing;

namespace CafeAroma_v2.Forms
{
    partial class FrmMonitoreo
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpMonitoreo;
        private DataGridView gridMonitoreo;

        private GroupBox grpConfirmar;
        private Label lblIdPedido;
        private TextBox txtIdPedido;
        private Button btnConfirmar;
        private Button btnRefrescar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpMonitoreo = new System.Windows.Forms.GroupBox();
            this.gridMonitoreo = new System.Windows.Forms.DataGridView();
            this.grpConfirmar = new System.Windows.Forms.GroupBox();
            this.lblIdPedido = new System.Windows.Forms.Label();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.grpMonitoreo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMonitoreo)).BeginInit();
            this.grpConfirmar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMonitoreo
            // 
            this.grpMonitoreo.Controls.Add(this.gridMonitoreo);
            this.grpMonitoreo.ForeColor = System.Drawing.Color.White;
            this.grpMonitoreo.Location = new System.Drawing.Point(18, 14);
            this.grpMonitoreo.Name = "grpMonitoreo";
            this.grpMonitoreo.Size = new System.Drawing.Size(884, 360);
            this.grpMonitoreo.TabIndex = 0;
            this.grpMonitoreo.TabStop = false;
            this.grpMonitoreo.Text = "Monitoreo de pedidos (estado / confirmación / fechas)";
            // 
            // gridMonitoreo
            // 
            this.gridMonitoreo.AllowUserToAddRows = false;
            this.gridMonitoreo.AllowUserToDeleteRows = false;
            this.gridMonitoreo.AllowUserToResizeRows = false;
            this.gridMonitoreo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMonitoreo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gridMonitoreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMonitoreo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridMonitoreo.ColumnHeadersHeight = 29;
            this.gridMonitoreo.EnableHeadersVisualStyles = false;
            this.gridMonitoreo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridMonitoreo.Location = new System.Drawing.Point(14, 25);
            this.gridMonitoreo.MultiSelect = false;
            this.gridMonitoreo.Name = "gridMonitoreo";
            this.gridMonitoreo.ReadOnly = true;
            this.gridMonitoreo.RowHeadersVisible = false;
            this.gridMonitoreo.RowHeadersWidth = 51;
            this.gridMonitoreo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMonitoreo.Size = new System.Drawing.Size(854, 320);
            this.gridMonitoreo.TabIndex = 0;
            // 
            // grpConfirmar
            // 
            this.grpConfirmar.Controls.Add(this.lblIdPedido);
            this.grpConfirmar.Controls.Add(this.txtIdPedido);
            this.grpConfirmar.Controls.Add(this.btnConfirmar);
            this.grpConfirmar.Controls.Add(this.btnRefrescar);
            this.grpConfirmar.ForeColor = System.Drawing.Color.White;
            this.grpConfirmar.Location = new System.Drawing.Point(18, 382);
            this.grpConfirmar.Name = "grpConfirmar";
            this.grpConfirmar.Size = new System.Drawing.Size(884, 96);
            this.grpConfirmar.TabIndex = 1;
            this.grpConfirmar.TabStop = false;
            this.grpConfirmar.Text = "Confirmación de recepción";
            // 
            // lblIdPedido
            // 
            this.lblIdPedido.AutoSize = true;
            this.lblIdPedido.Location = new System.Drawing.Point(20, 44);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(70, 16);
            this.lblIdPedido.TabIndex = 0;
            this.lblIdPedido.Text = "ID Pedido:";
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.Location = new System.Drawing.Point(90, 40);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(70, 22);
            this.txtIdPedido.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(180, 37);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(170, 30);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar recepción";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.DimGray;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(740, 37);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(128, 30);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // FrmMonitoreo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(920, 490);
            this.Controls.Add(this.grpMonitoreo);
            this.Controls.Add(this.grpConfirmar);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "FrmMonitoreo";
            this.Text = "Monitoreo de entregas y recepción";
            this.Load += new System.EventHandler(this.FrmMonitoreo_Load);
            this.grpMonitoreo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMonitoreo)).EndInit();
            this.grpConfirmar.ResumeLayout(false);
            this.grpConfirmar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
