namespace CafeAroma_v2.Forms
{
    partial class FrmProduccion_Reportes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupReportes = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCompletados = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.btnInforme = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupReportes
            // 
            this.groupReportes.Controls.Add(this.lblTotal);
            this.groupReportes.Controls.Add(this.lblCompletados);
            this.groupReportes.Controls.Add(this.lblPendientes);
            this.groupReportes.Controls.Add(this.btnInforme);
            this.groupReportes.ForeColor = System.Drawing.Color.White;
            this.groupReportes.Location = new System.Drawing.Point(40, 40);
            this.groupReportes.Name = "groupReportes";
            this.groupReportes.Size = new System.Drawing.Size(720, 320);
            this.groupReportes.TabIndex = 0;
            this.groupReportes.TabStop = false;
            this.groupReportes.Text = "Reportes e información";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(40, 60);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total:";
            // 
            // lblCompletados
            // 
            this.lblCompletados.Location = new System.Drawing.Point(40, 100);
            this.lblCompletados.Name = "lblCompletados";
            this.lblCompletados.Size = new System.Drawing.Size(100, 23);
            this.lblCompletados.TabIndex = 1;
            this.lblCompletados.Text = "Completados:";
            // 
            // lblPendientes
            // 
            this.lblPendientes.Location = new System.Drawing.Point(40, 140);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(100, 23);
            this.lblPendientes.TabIndex = 2;
            this.lblPendientes.Text = "Pendientes:";
            // 
            // btnInforme
            // 
            this.btnInforme.BackColor = System.Drawing.Color.Gold;
            this.btnInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInforme.ForeColor = System.Drawing.Color.Black;
            this.btnInforme.Location = new System.Drawing.Point(433, 250);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(267, 40);
            this.btnInforme.TabIndex = 3;
            this.btnInforme.Text = "Generar informe de producción";
            this.btnInforme.UseVisualStyleBackColor = false;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CafeAroma_v2.Properties.Resources.icon_cafe;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(340, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 223);
            this.panel1.TabIndex = 4;
            // 
            // FrmProduccion_Reportes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(820, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupReportes);
            this.Name = "FrmProduccion_Reportes";
            this.Text = "Gestión de Producción - Reportes";
            this.Load += new System.EventHandler(this.FrmProduccion_Reportes_Load);
            this.groupReportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupReportes;
        private System.Windows.Forms.Label lblTotal, lblCompletados, lblPendientes;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Panel panel1;
    }
}
