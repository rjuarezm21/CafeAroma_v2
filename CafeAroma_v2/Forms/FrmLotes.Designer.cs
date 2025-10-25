using System.Windows.Forms;
using System.Drawing;

namespace CafeAroma_v2.Forms
{
    partial class FrmLotes
    {
        private GroupBox grpLotes;
        private DataGridView gridLotes;
        private GroupBox grpDatos;
        private Label lblId;
        private TextBox txtIdLote;
        private Label lblNumero;
        private TextBox txtNumeroLote;
        private Label lblEstado;
        private ComboBox comboEstado;
        private Label lblFecha;
        private DateTimePicker dateVencimiento;
        private Button btnAgregar;
        private Button btnActualizar;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpLotes = new System.Windows.Forms.GroupBox();
            this.gridLotes = new System.Windows.Forms.DataGridView();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtIdLote = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dateVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.grpLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotes)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLotes
            // 
            this.grpLotes.Controls.Add(this.gridLotes);
            this.grpLotes.ForeColor = System.Drawing.Color.White;
            this.grpLotes.Location = new System.Drawing.Point(15, 15);
            this.grpLotes.Name = "grpLotes";
            this.grpLotes.Size = new System.Drawing.Size(870, 260);
            this.grpLotes.TabIndex = 0;
            this.grpLotes.TabStop = false;
            this.grpLotes.Text = "Listado de Lotes";
            // 
            // gridLotes
            // 
            this.gridLotes.AllowUserToAddRows = false;
            this.gridLotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Silver;
            this.gridLotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLotes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLotes.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLotes.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLotes.Location = new System.Drawing.Point(3, 18);
            this.gridLotes.Name = "gridLotes";
            this.gridLotes.ReadOnly = true;
            this.gridLotes.RowHeadersWidth = 51;
            this.gridLotes.Size = new System.Drawing.Size(864, 239);
            this.gridLotes.TabIndex = 0;
            this.gridLotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLotes_CellClick);
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblId);
            this.grpDatos.Controls.Add(this.txtIdLote);
            this.grpDatos.Controls.Add(this.lblNumero);
            this.grpDatos.Controls.Add(this.txtNumeroLote);
            this.grpDatos.Controls.Add(this.lblEstado);
            this.grpDatos.Controls.Add(this.comboEstado);
            this.grpDatos.Controls.Add(this.lblFecha);
            this.grpDatos.Controls.Add(this.dateVencimiento);
            this.grpDatos.Controls.Add(this.btnAgregar);
            this.grpDatos.Controls.Add(this.btnActualizar);
            this.grpDatos.ForeColor = System.Drawing.Color.White;
            this.grpDatos.Location = new System.Drawing.Point(15, 290);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(870, 160);
            this.grpDatos.TabIndex = 1;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Gestión de Lotes";
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 35);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // txtIdLote
            // 
            this.txtIdLote.Location = new System.Drawing.Point(23, 61);
            this.txtIdLote.Name = "txtIdLote";
            this.txtIdLote.ReadOnly = true;
            this.txtIdLote.Size = new System.Drawing.Size(70, 22);
            this.txtIdLote.TabIndex = 1;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(160, 35);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(100, 23);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "N° Lote:";
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Location = new System.Drawing.Point(163, 61);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.Size = new System.Drawing.Size(160, 22);
            this.txtNumeroLote.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(420, 35);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Items.AddRange(new object[] {
            "En proceso",
            "Listo",
            "Vencido"});
            this.comboEstado.Location = new System.Drawing.Point(423, 59);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(150, 24);
            this.comboEstado.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(660, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 23);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Vence:";
            // 
            // dateVencimiento
            // 
            this.dateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateVencimiento.Location = new System.Drawing.Point(663, 61);
            this.dateVencimiento.Name = "dateVencimiento";
            this.dateVencimiento.Size = new System.Drawing.Size(200, 22);
            this.dateVencimiento.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(248, 105);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(409, 105);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "Actualizar Estado";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmLotes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.grpLotes);
            this.Controls.Add(this.grpDatos);
            this.Name = "FrmLotes";
            this.Text = "Gestión de Lotes";
            this.Load += new System.EventHandler(this.FrmLotes_Load);
            this.grpLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLotes)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
