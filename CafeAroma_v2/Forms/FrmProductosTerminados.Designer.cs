namespace CafeAroma_v2.Forms
{
    partial class FrmProductosTerminados
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupRegistro = new System.Windows.Forms.GroupBox();
            this.comboProceso = new System.Windows.Forms.ComboBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.dateVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupHistorial = new System.Windows.Forms.GroupBox();
            this.listProductos = new System.Windows.Forms.ListBox();
            this.groupRegistro.SuspendLayout();
            this.groupHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegistro
            // 
            this.groupRegistro.Controls.Add(this.comboProceso);
            this.groupRegistro.Controls.Add(this.txtLote);
            this.groupRegistro.Controls.Add(this.comboEstado);
            this.groupRegistro.Controls.Add(this.dateVencimiento);
            this.groupRegistro.Controls.Add(this.btnRegistrar);
            this.groupRegistro.Controls.Add(this.label1);
            this.groupRegistro.Controls.Add(this.label2);
            this.groupRegistro.Controls.Add(this.label3);
            this.groupRegistro.Controls.Add(this.label4);
            this.groupRegistro.ForeColor = System.Drawing.Color.White;
            this.groupRegistro.Location = new System.Drawing.Point(25, 20);
            this.groupRegistro.Name = "groupRegistro";
            this.groupRegistro.Size = new System.Drawing.Size(770, 180);
            this.groupRegistro.TabIndex = 0;
            this.groupRegistro.TabStop = false;
            this.groupRegistro.Text = "Registrar Producto Terminado";
            // 
            // comboProceso
            // 
            this.comboProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProceso.Location = new System.Drawing.Point(150, 30);
            this.comboProceso.Name = "comboProceso";
            this.comboProceso.Size = new System.Drawing.Size(250, 24);
            this.comboProceso.TabIndex = 0;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(150, 70);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(200, 22);
            this.txtLote.TabIndex = 1;
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Items.AddRange(new object[] {
            "En Almacén",
            "Listo para entrega",
            "Finalizado"});
            this.comboEstado.Location = new System.Drawing.Point(150, 110);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(200, 24);
            this.comboEstado.TabIndex = 2;
            // 
            // dateVencimiento
            // 
            this.dateVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateVencimiento.Location = new System.Drawing.Point(500, 70);
            this.dateVencimiento.Name = "dateVencimiento";
            this.dateVencimiento.Size = new System.Drawing.Size(120, 22);
            this.dateVencimiento.TabIndex = 3;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(500, 110);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 35);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proceso:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Número de lote:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Estado:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(400, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha vencimiento:";
            // 
            // groupHistorial
            // 
            this.groupHistorial.Controls.Add(this.listProductos);
            this.groupHistorial.ForeColor = System.Drawing.Color.White;
            this.groupHistorial.Location = new System.Drawing.Point(25, 210);
            this.groupHistorial.Name = "groupHistorial";
            this.groupHistorial.Size = new System.Drawing.Size(770, 230);
            this.groupHistorial.TabIndex = 1;
            this.groupHistorial.TabStop = false;
            this.groupHistorial.Text = "Historial de productos terminados";
            // 
            // listProductos
            // 
            this.listProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listProductos.ForeColor = System.Drawing.Color.White;
            this.listProductos.ItemHeight = 16;
            this.listProductos.Location = new System.Drawing.Point(15, 30);
            this.listProductos.Name = "listProductos";
            this.listProductos.Size = new System.Drawing.Size(730, 180);
            this.listProductos.TabIndex = 0;
            // 
            // FrmProductosTerminados
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(820, 460);
            this.Controls.Add(this.groupRegistro);
            this.Controls.Add(this.groupHistorial);
            this.Name = "FrmProductosTerminados";
            this.Text = "Gestión de Productos Terminados";
            this.Load += new System.EventHandler(this.FrmProductosTerminados_Load);
            this.groupRegistro.ResumeLayout(false);
            this.groupRegistro.PerformLayout();
            this.groupHistorial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupRegistro;
        private System.Windows.Forms.ComboBox comboProceso, comboEstado;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.DateTimePicker dateVencimiento;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox groupHistorial;
        private System.Windows.Forms.ListBox listProductos;
        private System.Windows.Forms.Label label1, label2, label3, label4;
    }
}
