using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CafeAroma_v2.Forms
{
    public partial class FrmMain : MaterialForm
    {
        public FrmMain()
        {
            InitializeComponent();

            // ===============================================================
            // 🎨 Configuración del tema MaterialSkin
            // ===============================================================
            var materialManager = MaterialSkinManager.Instance;
            materialManager.AddFormToManage(this);
            materialManager.Theme = MaterialSkinManager.Themes.DARK;
            materialManager.ColorScheme = new ColorScheme(
                Primary.Brown700, Primary.Brown900,
                Primary.Brown500, Accent.Orange700,
                TextShade.WHITE);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1000, 650);

            // ===============================================================
            // 🖼️ Cargar íconos en el menú lateral (TreeView)
            // ===============================================================
            var imgList = new ImageList { ImageSize = new Size(18, 18) };
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                imgList.Images.Add(Image.FromFile(Path.Combine(baseDir, "Recursos", "icon_materia.png")));      // 0
                imgList.Images.Add(Image.FromFile(Path.Combine(baseDir, "Recursos", "icon_produccion.png")));   // 1
                imgList.Images.Add(Image.FromFile(Path.Combine(baseDir, "Recursos", "icon_producto.png")));     // 2
                imgList.Images.Add(Image.FromFile(Path.Combine(baseDir, "Recursos", "icon_pedidos.png")));      // 3
                imgList.Images.Add(Image.FromFile(Path.Combine(baseDir, "Recursos", "icon_reportes.png")));     // 4
            }
            catch { /* Si no hay íconos, continúa sin error */ }

            treeViewMenu.ImageList = imgList;
            treeViewMenu.AfterSelect += TreeViewMenu_AfterSelect;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CargarMenuTreeView();
        }

        // ===============================================================
        // 📂 Construcción del menú jerárquico completo
        // ===============================================================
        private void CargarMenuTreeView()
        {
            treeViewMenu.Nodes.Clear();

            // ===============================
            // 🟤 GESTIÓN DE MATERIA PRIMA
            // ===============================
            TreeNode nodoMateriaPrima = new TreeNode("Gestión de Materia Prima")
            {
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            nodoMateriaPrima.Nodes.Add(new TreeNode("Registro de granos verdes"));
            nodoMateriaPrima.Nodes.Add(new TreeNode("Control de inventario"));
            nodoMateriaPrima.Nodes.Add(new TreeNode("Órdenes de compra"));

            // ===============================
            // 🟠 GESTIÓN DE PRODUCCIÓN
            // ===============================
            TreeNode nodoProduccion = new TreeNode("Gestión de Producción")
            {
                ImageIndex = 1,
                SelectedImageIndex = 1
            };
            nodoProduccion.Nodes.Add(new TreeNode("Registrar proceso"));
            nodoProduccion.Nodes.Add(new TreeNode("Control de producción"));
            nodoProduccion.Nodes.Add(new TreeNode("Reportes de producción"));

            // ===============================
            // 🟡 GESTIÓN DE PRODUCTOS TERMINADOS
            // ===============================
            TreeNode nodoProductos = new TreeNode("Gestión de Productos Terminados")
            {
                ImageIndex = 2,
                SelectedImageIndex = 2
            };
            nodoProductos.Nodes.Add(new TreeNode("Finalización del producto"));
            nodoProductos.Nodes.Add(new TreeNode("Lotes y vencimiento"));

            // ===============================
            // 🟢 GESTIÓN DE PEDIDOS Y DISTRIBUCIÓN
            // ===============================
            TreeNode nodoPedidos = new TreeNode("Gestión de Pedidos y Distribución")
            {
                ImageIndex = 3,
                SelectedImageIndex = 3
            };
            nodoPedidos.Nodes.Add(new TreeNode("Agregar Pedido"));
            nodoPedidos.Nodes.Add(new TreeNode("Entregas"));
            nodoPedidos.Nodes.Add(new TreeNode("Monitoreo de entregas"));

            // ===============================
            // 🔵 REPORTES GENERALES
            // ===============================
            TreeNode nodoReportes = new TreeNode("Reportes y Análisis")
            {
                ImageIndex = 4,
                SelectedImageIndex = 4
            };
            nodoReportes.Nodes.Add(new TreeNode("Reporte general de operaciones"));

            // Agregar todos los nodos al menú principal
            treeViewMenu.Nodes.Add(nodoMateriaPrima);
            treeViewMenu.Nodes.Add(nodoProduccion);
            treeViewMenu.Nodes.Add(nodoProductos);
            treeViewMenu.Nodes.Add(nodoPedidos);
            treeViewMenu.Nodes.Add(nodoReportes);

            treeViewMenu.ExpandAll();
        }

        // ===============================================================
        // 🧩 Controlador de selección (abrir formularios)
        // ===============================================================
        private void TreeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form frm = null;

            switch (e.Node.Text)
            {
                // 🟤 MATERIA PRIMA
                case "Registro de granos verdes":
                    frm = new FrmGranosVerdes();
                    break;

                case "Control de inventario":
                    frm = new FrmControlInventario();
                    break;

                case "Órdenes de compra":
                    frm = new FrmOrdenCompra();
                    break;

                // 🟠 PRODUCCIÓN
                case "Registrar proceso":
                    frm = new FrmProduccion_Registro();
                    break;

                case "Control de producción":
                    frm = new FrmProduccion_Control();
                    break;

                case "Reportes de producción":
                    frm = new FrmProduccion_Reportes();
                    break;

                // 🟡 PRODUCTOS TERMINADOS
                case "Finalización del producto":
                    frm = new FrmProductosTerminados();
                    break;

                case "Lotes y vencimiento":
                    frm = new FrmLotes();
                    break;

                // 🟢 PEDIDOS Y DISTRIBUCIÓN
                case "Agregar Pedido":
                    frm = new FrmAgregarPedido();
                    break;

                case "Entregas":
                    frm = new FrmEntregas();
                    break;

                case "Monitoreo de entregas":
                    frm = new FrmMonitoreo();
                    break;

                // 🔵 REPORTES GENERALES
                case "Reporte general de operaciones":
                    frm = new FrmReportesGenerales();
                    break;
            }

            // Mostrar el formulario seleccionado dentro del panel
            if (frm != null)
            {
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                panelContenido.Controls.Clear();
                panelContenido.Controls.Add(frm);
                frm.Show();
            }
        }
    }
}
