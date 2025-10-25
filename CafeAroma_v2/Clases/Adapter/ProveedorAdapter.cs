using CafeAroma_v2.Clases.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace CafeAroma_v2.Clases.Adapter
{
    public class ProveedorAdapter
    {
        public List<Proveedor> AdaptarProveedores(DataTable dt)
        {
            var proveedores = new List<Proveedor>();

            foreach (DataRow row in dt.Rows)
            {
                var proveedor = new Proveedor
                {
                    IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                    Nombre = row["nombre"].ToString()
                };
                proveedores.Add(proveedor);
            }

            return proveedores;
        }
    }

    // Clase que representa al proveedor
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
    }
}
