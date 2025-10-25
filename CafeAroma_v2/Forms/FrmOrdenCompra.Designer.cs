namespace CafeAroma_v2.Forms
{
    partial class FrmOrdenCompra
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupAuto = new System.Windows.Forms.GroupBox();
            this.lblUmbral = new System.Windows.Forms.Label();
            this.numUmbral = new System.Windows.Forms.NumericUpDown();
            this.lblReponer = new System.Windows.Forms.Label();
            this.numReponer = new System.Windows.Forms.NumericUpDown();
            this.btnGenerarAuto = new System.Windows.Forms.Button();
            this.lblAutoStatus = new System.Windows.Forms.Label();
            this.groupManual = new System.Windows.Forms.GroupBox();
            this.lblManualGrano = new System.Windows.Forms.Label();
            this.comboManualGrano = new System.Windows.Forms.ComboBox();
            this.lblManualCantidad = new System.Windows.Forms.Label();
            this.numManualCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnGenerarManual = new System.Windows.Forms.Button();
            this.groupLista = new System.Windows.Forms.GroupBox();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.groupAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUmbral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReponer)).BeginInit();
            this.groupManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numManualCantidad)).BeginInit();
            this.groupLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAuto
            // 
            this.groupAuto.Controls.Add(this.lblUmbral);
            this.groupAuto.Controls.Add(this.numUmbral);
            this.groupAuto.Controls.Add(this.lblReponer);
            this.groupAuto.Controls.Add(this.numReponer);
            this.groupAuto.Controls.Add(this.btnGenerarAuto);
            this.groupAuto.Controls.Add(this.lblAutoStatus);
            this.groupAuto.ForeColor = System.Drawing.Color.White;
            this.groupAuto.Location = new System.Drawing.Point(20, 20);
            this.groupAuto.Name = "groupAuto";
            this.groupAuto.Size = new System.Drawing.Size(930, 90);
            this.groupAuto.TabIndex = 0;
            this.groupAuto.TabStop = false;
            this.groupAuto.Text = "Parámetros de generación automática";
            // 
            // lblUmbral
            // 
            this.lblUmbral.Location = new System.Drawing.Point(25, 35);
            this.lblUmbral.Name = "lblUmbral";
            this.lblUmbral.Size = new System.Drawing.Size(90, 20);
            this.lblUmbral.TabIndex = 0;
            this.lblUmbral.Text = "Umbral (stock):";
            // 
            // numUmbral
            // 
            this.numUmbral.Location = new System.Drawing.Point(120, 32);
            this.numUmbral.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUmbral.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUmbral.Name = "numUmbral";
            this.numUmbral.Size = new System.Drawing.Size(70, 22);
            this.numUmbral.TabIndex = 1;
            this.numUmbral.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblReponer
            // 
            this.lblReponer.Location = new System.Drawing.Point(220, 35);
            this.lblReponer.Name = "lblReponer";
            this.lblReponer.Size = new System.Drawing.Size(70, 20);
            this.lblReponer.TabIndex = 2;
            this.lblReponer.Text = "Reponer:";
            // 
            // numReponer
            // 
            this.numReponer.Location = new System.Drawing.Point(290, 32);
            this.numReponer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReponer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReponer.Name = "numReponer";
            this.numReponer.Size = new System.Drawing.Size(70, 22);
            this.numReponer.TabIndex = 3;
            this.numReponer.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnGenerarAuto
            // 
            this.btnGenerarAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerarAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarAuto.ForeColor = System.Drawing.Color.White;
            this.btnGenerarAuto.Location = new System.Drawing.Point(380, 28);
            this.btnGenerarAuto.Name = "btnGenerarAuto";
            this.btnGenerarAuto.Size = new System.Drawing.Size(100, 30);
            this.btnGenerarAuto.TabIndex = 4;
            this.btnGenerarAuto.Text = "Generar";
            this.btnGenerarAuto.UseVisualStyleBackColor = false;
            this.btnGenerarAuto.Click += new System.EventHandler(this.btnGenerarAuto_Click);
            // 
            // lblAutoStatus
            // 
            this.lblAutoStatus.ForeColor = System.Drawing.Color.LightGray;
            this.lblAutoStatus.Location = new System.Drawing.Point(520, 35);
            this.lblAutoStatus.Name = "lblAutoStatus";
            this.lblAutoStatus.Size = new System.Drawing.Size(250, 20);
            this.lblAutoStatus.TabIndex = 5;
            this.lblAutoStatus.Text = "Revisión automática completada.";
            // 
            // groupManual
            // 
            this.groupManual.Controls.Add(this.lblManualGrano);
            this.groupManual.Controls.Add(this.comboManualGrano);
            this.groupManual.Controls.Add(this.lblManualCantidad);
            this.groupManual.Controls.Add(this.numManualCantidad);
            this.groupManual.Controls.Add(this.btnGenerarManual);
            this.groupManual.ForeColor = System.Drawing.Color.White;
            this.groupManual.Location = new System.Drawing.Point(20, 120);
            this.groupManual.Name = "groupManual";
            this.groupManual.Size = new System.Drawing.Size(930, 100);
            this.groupManual.TabIndex = 1;
            this.groupManual.TabStop = false;
            this.groupManual.Text = "Generar nueva orden de compra manual";
            // 
            // lblManualGrano
            // 
            this.lblManualGrano.Location = new System.Drawing.Point(25, 40);
            this.lblManualGrano.Name = "lblManualGrano";
            this.lblManualGrano.Size = new System.Drawing.Size(100, 20);
            this.lblManualGrano.TabIndex = 0;
            this.lblManualGrano.Text = "Tipo de grano:";
            // 
            // comboManualGrano
            // 
            this.comboManualGrano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboManualGrano.Location = new System.Drawing.Point(130, 37);
            this.comboManualGrano.Name = "comboManualGrano";
            this.comboManualGrano.Size = new System.Drawing.Size(180, 24);
            this.comboManualGrano.TabIndex = 1;
            // 
            // lblManualCantidad
            // 
            this.lblManualCantidad.Location = new System.Drawing.Point(340, 40);
            this.lblManualCantidad.Name = "lblManualCantidad";
            this.lblManualCantidad.Size = new System.Drawing.Size(70, 20);
            this.lblManualCantidad.TabIndex = 2;
            this.lblManualCantidad.Text = "Cantidad:";
            // 
            // numManualCantidad
            // 
            this.numManualCantidad.Location = new System.Drawing.Point(410, 37);
            this.numManualCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numManualCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numManualCantidad.Name = "numManualCantidad";
            this.numManualCantidad.Size = new System.Drawing.Size(90, 22);
            this.numManualCantidad.TabIndex = 3;
            this.numManualCantidad.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnGenerarManual
            // 
            this.btnGenerarManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerarManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarManual.ForeColor = System.Drawing.Color.White;
            this.btnGenerarManual.Location = new System.Drawing.Point(530, 33);
            this.btnGenerarManual.Name = "btnGenerarManual";
            this.btnGenerarManual.Size = new System.Drawing.Size(160, 30);
            this.btnGenerarManual.TabIndex = 4;
            this.btnGenerarManual.Text = "Generar Orden Manual";
            this.btnGenerarManual.UseVisualStyleBackColor = false;
            this.btnGenerarManual.Click += new System.EventHandler(this.btnGenerarManual_Click);
            // 
            // groupLista
            // 
            this.groupLista.Controls.Add(this.dgvOrdenes);
            this.groupLista.Controls.Add(this.btnRefrescar);
            this.groupLista.ForeColor = System.Drawing.Color.White;
            this.groupLista.Location = new System.Drawing.Point(20, 230);
            this.groupLista.Name = "groupLista";
            this.groupLista.Size = new System.Drawing.Size(930, 330);
            this.groupLista.TabIndex = 2;
            this.groupLista.TabStop = false;
            this.groupLista.Text = "Órdenes de compra registradas";
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Silver;
            this.dgvOrdenes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenes.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvOrdenes.Location = new System.Drawing.Point(20, 30);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.Size = new System.Drawing.Size(880, 250);
            this.dgvOrdenes.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.Black;
            this.btnRefrescar.Location = new System.Drawing.Point(820, 285);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(80, 30);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // FrmOrdenCompra
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(980, 590);
            this.Controls.Add(this.groupAuto);
            this.Controls.Add(this.groupManual);
            this.Controls.Add(this.groupLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenCompra";
            this.Text = "Gestión de Órdenes de Compra";
            this.Load += new System.EventHandler(this.FrmOrdenCompra_Load_1);
            this.groupAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUmbral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReponer)).EndInit();
            this.groupManual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numManualCantidad)).EndInit();
            this.groupLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAuto;
        private System.Windows.Forms.Label lblUmbral;
        private System.Windows.Forms.Label lblReponer;
        private System.Windows.Forms.NumericUpDown numUmbral;
        private System.Windows.Forms.NumericUpDown numReponer;
        private System.Windows.Forms.Button btnGenerarAuto;
        private System.Windows.Forms.Label lblAutoStatus;

        private System.Windows.Forms.GroupBox groupManual;
        private System.Windows.Forms.Label lblManualGrano;
        private System.Windows.Forms.Label lblManualCantidad;
        private System.Windows.Forms.ComboBox comboManualGrano;
        private System.Windows.Forms.NumericUpDown numManualCantidad;
        private System.Windows.Forms.Button btnGenerarManual;

        private System.Windows.Forms.GroupBox groupLista;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btnRefrescar;
    }
}
