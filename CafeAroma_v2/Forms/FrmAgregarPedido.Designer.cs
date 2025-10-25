using System.Windows.Forms;

namespace CafeAroma_v2.Forms
{
    partial class FrmAgregarPedido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboTienda = new System.Windows.Forms.ComboBox();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.radioRapida = new System.Windows.Forms.RadioButton();
            this.radioEconomica = new System.Windows.Forms.RadioButton();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboTienda);
            this.groupBox1.Controls.Add(this.comboProveedor);
            this.groupBox1.Controls.Add(this.radioRapida);
            this.groupBox1.Controls.Add(this.radioEconomica);
            this.groupBox1.Controls.Add(this.txtRuta);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Pedido";
            // 
            // comboTienda
            // 
            this.comboTienda.Location = new System.Drawing.Point(30, 40);
            this.comboTienda.Name = "comboTienda";
            this.comboTienda.Size = new System.Drawing.Size(200, 24);
            this.comboTienda.TabIndex = 0;
            // 
            // comboProveedor
            // 
            this.comboProveedor.Location = new System.Drawing.Point(260, 40);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(200, 24);
            this.comboProveedor.TabIndex = 1;
            // 
            // radioRapida
            // 
            this.radioRapida.Location = new System.Drawing.Point(500, 40);
            this.radioRapida.Name = "radioRapida";
            this.radioRapida.Size = new System.Drawing.Size(104, 24);
            this.radioRapida.TabIndex = 2;
            this.radioRapida.Text = "Rápida";
            // 
            // radioEconomica
            // 
            this.radioEconomica.Location = new System.Drawing.Point(610, 40);
            this.radioEconomica.Name = "radioEconomica";
            this.radioEconomica.Size = new System.Drawing.Size(104, 24);
            this.radioEconomica.TabIndex = 3;
            this.radioEconomica.Text = "Económica";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(30, 90);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(300, 22);
            this.txtRuta.TabIndex = 4;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(30, 130);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(550, 22);
            this.txtObservaciones.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(600, 180);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar Pedido";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FrmAgregarPedido
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAgregarPedido";
            this.Text = "Agregar Pedido";
            this.Load += new System.EventHandler(this.FrmAgregarPedido_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboTienda, comboProveedor;
        private System.Windows.Forms.RadioButton radioRapida, radioEconomica;
        private System.Windows.Forms.TextBox txtRuta, txtObservaciones;
        private System.Windows.Forms.Button btnRegistrar;
    }
}
