using CafeAroma_v2.Clases.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeAroma_v2.Clases.Adapter;

namespace CafeAroma_v2.Forms
{
    public partial class FrmAgregarPedido : Form
    {
        public FrmAgregarPedido()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboTienda.SelectedIndex == -1 || comboProveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una tienda y un proveedor.");
                    return;
                }

                string tipoEntrega = radioRapida.Checked ? "Rápida" : "Económica";

                var parametros = new Dictionary<string, object>
                {
                    { "p_id_tienda", Convert.ToInt32(comboTienda.SelectedValue) },
                    { "p_id_proveedor", Convert.ToInt32(comboProveedor.SelectedValue) },
                    { "p_tipo_entrega", tipoEntrega },
                    { "p_ruta_asignada", txtRuta.Text.Trim() },
                    { "p_observaciones", txtObservaciones.Text.Trim() }
                };

                ConexionBD.Instancia.EjecutarSP("sp_insertar_pedido", parametros);
                MessageBox.Show("✅ Pedido registrado correctamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar pedido: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            comboTienda.SelectedIndex = -1;
            comboProveedor.SelectedIndex = -1;
            radioEconomica.Checked = true;
            txtRuta.Clear();
            txtObservaciones.Clear();
        }
        

        private void FrmAgregarPedido_Load(object sender, EventArgs e)
        {
            CargarTiendas();
            CargarProveedores();
        }
        private void CargarTiendas()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_tiendas", parametros);
                comboTienda.DataSource = dt;
                comboTienda.DisplayMember = "nombre";
                comboTienda.ValueMember = "id_tienda";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tiendas: " + ex.Message);
            }
        }

        private void CargarProveedores()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                DataTable dt = ConexionBD.Instancia.EjecutarSPConResultado("sp_listar_proveedores", parametros);

                // Usamos el adaptador para transformar el DataTable en una lista de objetos Proveedor
                var proveedorAdapter = new ProveedorAdapter();
                var proveedores = proveedorAdapter.AdaptarProveedores(dt);

                // Asignamos los proveedores al comboBox
                comboProveedor.DataSource = proveedores;
                comboProveedor.DisplayMember = "Nombre";  // 'Nombre' es el campo de la clase Proveedor
                comboProveedor.ValueMember = "IdProveedor";  // 'IdProveedor' es el campo de la clase Proveedor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

    }
}
