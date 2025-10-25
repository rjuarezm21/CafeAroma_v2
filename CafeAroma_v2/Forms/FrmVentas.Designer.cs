namespace CafeAroma_v2.Forms
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtDatos; private System.Windows.Forms.Button btnEnviar;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblTitulo.Text = "Gestión de Ventas";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Top = 12; this.lblTitulo.Left = 12; this.lblTitulo.Width = 400;
            this.txtDatos.Top = 50; this.txtDatos.Left = 12; this.txtDatos.Width = 600; this.txtDatos.Height = 200; this.txtDatos.Multiline = true;
            this.btnEnviar.Top = 270; this.btnEnviar.Left = 12; this.btnEnviar.Text = "Enviar Factura"; this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.btnEnviar);
            this.BackColor = System.Drawing.Color.FromArgb(30,30,30);
            this.ClientSize = new System.Drawing.Size(800,500);
            this.ResumeLayout(false);
        }
    }
}
