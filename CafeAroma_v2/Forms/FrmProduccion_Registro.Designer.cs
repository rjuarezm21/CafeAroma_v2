namespace CafeAroma_v2.Forms
{
    partial class FrmProduccion_Registro
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupRegistro = new System.Windows.Forms.GroupBox();
            this.comboGrano = new System.Windows.Forms.ComboBox();
            this.comboEtapa = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listProcesos = new System.Windows.Forms.ListBox();
            this.groupProcesos = new System.Windows.Forms.GroupBox();

            this.groupRegistro.SuspendLayout();
            this.groupProcesos.SuspendLayout();
            this.SuspendLayout();

            // 
            // groupRegistro
            // 
            this.groupRegistro.Controls.Add(this.comboGrano);
            this.groupRegistro.Controls.Add(this.comboEtapa);
            this.groupRegistro.Controls.Add(this.txtCantidad);
            this.groupRegistro.Controls.Add(this.txtDescripcion);
            this.groupRegistro.Controls.Add(this.btnRegistrar);
            this.groupRegistro.Controls.Add(this.label1);
            this.groupRegistro.Controls.Add(this.label2);
            this.groupRegistro.Controls.Add(this.label3);
            this.groupRegistro.Controls.Add(this.label4);
            this.groupRegistro.ForeColor = System.Drawing.Color.White;
            this.groupRegistro.Location = new System.Drawing.Point(20, 15);
            this.groupRegistro.Name = "groupRegistro";
            this.groupRegistro.Size = new System.Drawing.Size(780, 160);
            this.groupRegistro.TabIndex = 0;
            this.groupRegistro.TabStop = false;
            this.groupRegistro.Text = "Registrar nuevo proceso";

            // 
            // comboGrano
            // 
            this.comboGrano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrano.FormattingEnabled = true;
            this.comboGrano.Location = new System.Drawing.Point(100, 30);
            this.comboGrano.Name = "comboGrano";
            this.comboGrano.Size = new System.Drawing.Size(200, 24);

            // 
            // comboEtapa
            // 
            this.comboEtapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEtapa.FormattingEnabled = true;
            this.comboEtapa.Location = new System.Drawing.Point(480, 30);
            this.comboEtapa.Name = "comboEtapa";
            this.comboEtapa.Size = new System.Drawing.Size(200, 24);

            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(100, 70);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 22);

            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(100, 110);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(480, 22);

            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(600, 105);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 30);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // 
            // Labels
            // 
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Text = "Tipo de:";
            this.label2.Location = new System.Drawing.Point(390, 33);
            this.label2.Text = "Etapa del:";
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Text = "Cantidad:";
            this.label4.Location = new System.Drawing.Point(20, 113);
            this.label4.Text = "Descripción:";

            // 
            // groupProcesos
            // 
            this.groupProcesos.Controls.Add(this.listProcesos);
            this.groupProcesos.ForeColor = System.Drawing.Color.White;
            this.groupProcesos.Location = new System.Drawing.Point(20, 190);
            this.groupProcesos.Name = "groupProcesos";
            this.groupProcesos.Size = new System.Drawing.Size(780, 230);
            this.groupProcesos.Text = "Procesos registrados";

            // 
            // listProcesos
            // 
            this.listProcesos.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.listProcesos.ForeColor = System.Drawing.Color.White;
            this.listProcesos.FormattingEnabled = true;
            this.listProcesos.ItemHeight = 16;
            this.listProcesos.Location = new System.Drawing.Point(15, 30);
            this.listProcesos.Name = "listProcesos";
            this.listProcesos.Size = new System.Drawing.Size(740, 180);

            // 
            // FrmProduccion_Registro
            // 
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize = new System.Drawing.Size(820, 440);
            this.Controls.Add(this.groupRegistro);
            this.Controls.Add(this.groupProcesos);
            this.Name = "FrmProduccion_Registro";
            this.Text = "Gestión de Producción - Registro";
            this.Load += new System.EventHandler(this.FrmProduccion_Registro_Load);

            this.groupRegistro.ResumeLayout(false);
            this.groupRegistro.PerformLayout();
            this.groupProcesos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupRegistro;
        private System.Windows.Forms.GroupBox groupProcesos;
        private System.Windows.Forms.ComboBox comboGrano;
        private System.Windows.Forms.ComboBox comboEtapa;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ListBox listProcesos;
        private System.Windows.Forms.Label label1, label2, label3, label4;
    }
}
