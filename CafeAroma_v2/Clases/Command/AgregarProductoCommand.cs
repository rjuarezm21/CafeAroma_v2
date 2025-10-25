using CafeAroma_v2.Clases.Database;
using CafeAroma_v2.Clases.Entidades;
using CafeAroma_v2.Clases.Singleton;
using System.Collections.Generic;

namespace CafeAroma_v2.Clases.Command
{
    public class AgregarProductoCommand : ICommand
    {
        private readonly Producto p;

        public AgregarProductoCommand(Producto producto) => p = producto;

        public void Ejecutar()
        {
            GestorDelInventario.Instancia.AgregarProducto(p);

            var parametros = new Dictionary<string, object>
            {
                { "@p_nombre", p.Nombre },
                { "@p_id_grano", p.IdGrano },
                { "@p_cantidad", p.Cantidad },
                { "@p_precio", p.Precio }
            };

            ConexionBD.Instancia.EjecutarSP("sp_insertar_producto", parametros);
        }

        public void Deshacer()
        {
            GestorDelInventario.Instancia.QuitarProducto(p.Nombre, p.Cantidad);
        }
    }
}
