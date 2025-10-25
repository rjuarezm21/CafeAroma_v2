using System.Windows.Forms;
using System.Drawing;

namespace CafeAroma_v2.Forms
{
    partial class FrmEntregas
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpListado;
        private DataGridView gridPedidos;

        private GroupBox grpAcciones;
        private Label lblId;
        private TextBox txtIdPedido;
        private Label lblEstado;
        private ComboBox comboEstado;
        private Label lblFecha;
        private DateTimePicker dateEntrega;
        private Button btnActualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpListado = new System.Windows.Forms.GroupBox();
            this.gridPedidos = new System.Windows.Forms.DataGridView();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dateEntrega = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPedidos)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpListado
            // 
            this.grpListado.Controls.Add(this.gridPedidos);
            this.grpListado.ForeColor = System.Drawing.Color.White;
            this.grpListado.Location = new System.Drawing.Point(18, 14);
            this.grpListado.Name = "grpListado";
            this.grpListado.Size = new System.Drawing.Size(884, 360);
            this.grpListado.TabIndex = 0;
            this.grpListado.TabStop = false;
            this.grpListado.Text = "Pedidos (tienda / proveedor / tipo / estado / ruta)";
            // 
            // gridPedidos
            // 
            this.gridPedidos.AllowUserToAddRows = false;
            this.gridPedidos.AllowUserToDeleteRows = false;
            this.gridPedidos.AllowUserToResizeRows = false;
            this.gridPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gridPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPedidos.ColumnHeadersHeight = 29;
            this.gridPedidos.EnableHeadersVisualStyles = false;
            this.gridPedidos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridPedidos.Location = new System.Drawing.Point(14, 25);
            this.gridPedidos.MultiSelect = false;
            this.gridPedidos.Name = "gridPedidos";
            this.gridPedidos.ReadOnly = true;
            this.gridPedidos.RowHeadersVisible = false;
            this.gridPedidos.RowHeadersWidth = 51;
            this.gridPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPedidos.Size = new System.Drawing.Size(854, 320);
            this.gridPedidos.TabIndex = 0;
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.lblId);
            this.grpAcciones.Controls.Add(this.txtIdPedido);
            this.grpAcciones.Controls.Add(this.lblEstado);
            this.grpAcciones.Controls.Add(this.comboEstado);
            this.grpAcciones.Controls.Add(this.lblFecha);
            this.grpAcciones.Controls.Add(this.dateEntrega);
            this.grpAcciones.Controls.Add(this.btnActualizar);
            this.grpAcciones.ForeColor = System.Drawing.Color.White;
            this.grpAcciones.Location = new System.Drawing.Point(18, 382);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(884, 96);
            this.grpAcciones.TabIndex = 1;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Actualizar estado de entrega";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 44);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(70, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID Pedido:";
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.Location = new System.Drawing.Point(90, 40);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(70, 22);
            this.txtIdPedido.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(180, 44);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(53, 16);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Items.AddRange(new object[] {
            "Pendiente",
            "En ruta",
            "Entregado",
            "Devuelto",
            "Cancelado"});
            this.comboEstado.Location = new System.Drawing.Point(235, 40);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(160, 24);
            this.comboEstado.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(415, 44);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(97, 16);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha entrega:";
            // 
            // dateEntrega
            // 
            this.dateEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEntrega.Location = new System.Drawing.Point(528, 42);
            this.dateEntrega.Name = "dateEntrega";
            this.dateEntrega.Size = new System.Drawing.Size(110, 22);
            this.dateEntrega.TabIndex = 5;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(740, 37);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(128, 30);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar estado";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmEntregas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(920, 490);
            this.Controls.Add(this.grpListado);
            this.Controls.Add(this.grpAcciones);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "FrmEntregas";
            this.Text = "Entregas y rutas";
            this.Load += new System.EventHandler(this.FrmEntregas_Load);
            this.grpListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPedidos)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.grpAcciones.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
