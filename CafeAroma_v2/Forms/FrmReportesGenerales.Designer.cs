using System.Windows.Forms;
using System.Drawing;

namespace CafeAroma_v2.Forms
{
    partial class FrmReportesGenerales
    {
        private ComboBox comboTipoReporte;
        private Button btnGenerar;
        private DataGridView gridReportes;
        private Label lblTipo;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboTipoReporte = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gridReportes = new System.Windows.Forms.DataGridView();
            this.lblTipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTipoReporte
            // 
            this.comboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoReporte.Items.AddRange(new object[] {
            "Inventario",
            "Producción",
            "Pedidos",
            "Lotes"});
            this.comboTipoReporte.Location = new System.Drawing.Point(220, 22);
            this.comboTipoReporte.Name = "comboTipoReporte";
            this.comboTipoReporte.Size = new System.Drawing.Size(180, 24);
            this.comboTipoReporte.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Orange;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(420, 20);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // gridReportes
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gridReportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridReportes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.gridReportes.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReportes.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridReportes.Location = new System.Drawing.Point(25, 70);
            this.gridReportes.Name = "gridReportes";
            this.gridReportes.RowHeadersWidth = 51;
            this.gridReportes.Size = new System.Drawing.Size(830, 370);
            this.gridReportes.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(30, 25);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Seleccione tipo de reporte:";
            // 
            // FrmReportesGenerales
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(880, 480);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.comboTipoReporte);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.gridReportes);
            this.Name = "FrmReportesGenerales";
            this.Text = "Reportes Generales";
            this.Load += new System.EventHandler(this.FrmReportesGenerales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReportes)).EndInit();
            this.ResumeLayout(false);

            this.gridReportes.EnableHeadersVisualStyles = false;
            this.gridReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            this.gridReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.gridReportes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            
            this.gridReportes.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            this.gridReportes.DefaultCellStyle.ForeColor = Color.White;
            this.gridReportes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 70, 20);  // Café oscuro
            this.gridReportes.DefaultCellStyle.SelectionForeColor = Color.White;
            
            this.gridReportes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            this.gridReportes.GridColor = Color.FromArgb(70, 50, 30);
           
            this.gridReportes.BorderStyle = BorderStyle.None;
            this.gridReportes.RowHeadersVisible = false;
            this.gridReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
