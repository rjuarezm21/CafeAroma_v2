namespace CafeAroma_v2.Forms
{
    partial class FrmProduccion_Control
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.listProcesos = new System.Windows.Forms.ListBox();
            this.txtIdProceso = new System.Windows.Forms.TextBox();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.listProcesos);
            this.groupControl.Controls.Add(this.txtIdProceso);
            this.groupControl.Controls.Add(this.comboEstado);
            this.groupControl.Controls.Add(this.btnActualizar);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.ForeColor = System.Drawing.Color.White;
            this.groupControl.Location = new System.Drawing.Point(20, 20);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(780, 400);
            this.groupControl.TabIndex = 0;
            this.groupControl.TabStop = false;
            this.groupControl.Text = "Monitoreo y control de procesos";
            // 
            // listProcesos
            // 
            this.listProcesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listProcesos.ForeColor = System.Drawing.Color.White;
            this.listProcesos.ItemHeight = 16;
            this.listProcesos.Location = new System.Drawing.Point(20, 30);
            this.listProcesos.Name = "listProcesos";
            this.listProcesos.Size = new System.Drawing.Size(740, 244);
            this.listProcesos.TabIndex = 0;
            // 
            // txtIdProceso
            // 
            this.txtIdProceso.Location = new System.Drawing.Point(120, 300);
            this.txtIdProceso.Name = "txtIdProceso";
            this.txtIdProceso.Size = new System.Drawing.Size(80, 22);
            this.txtIdProceso.TabIndex = 1;
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Location = new System.Drawing.Point(320, 300);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(150, 24);
            this.comboEstado.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(500, 295);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 35);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar Estado";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID Proceso:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(230, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nuevo Estado:";
            // 
            // FrmProduccion_Control
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(820, 440);
            this.Controls.Add(this.groupControl);
            this.Name = "FrmProduccion_Control";
            this.Text = "Gestión de Producción - Control";
            this.Load += new System.EventHandler(this.FrmProduccion_Control_Load);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.ListBox listProcesos;
        private System.Windows.Forms.TextBox txtIdProceso;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label1, label2;
    }
}
