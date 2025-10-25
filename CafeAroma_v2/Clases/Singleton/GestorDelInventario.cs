using System;
using System.Collections.Generic;
using CafeAroma_v2.Clases.Entidades;

namespace CafeAroma_v2.Clases.Singleton
{
    /// <summary>
    /// Singleton encargado de manejar el inventario de granos y productos terminados.
    /// </summary>
    public sealed class GestorDelInventario
    {
        // Instancia única
        private static readonly GestorDelInventario instancia = new GestorDelInventario();

        // Inventarios separados
        private readonly Dictionary<string, int> inventarioGranos;
        private readonly Dictionary<string, int> inventarioProductos;

        // Constructor
        private GestorDelInventario()
        {
            inventarioGranos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            inventarioProductos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        // Acceso global
        public static GestorDelInventario Instancia => instancia;

        // ============================================================
        // Sección: GESTIÓN DE GRANOS
        // ============================================================
        public void AgregarGrano(Grano grano)
        {
            if (inventarioGranos.ContainsKey(grano.Tipo))
                inventarioGranos[grano.Tipo] += grano.Cantidad;
            else
                inventarioGranos[grano.Tipo] = grano.Cantidad;
        }

        public void QuitarGrano(string tipo, int cantidad)
        {
            if (inventarioGranos.ContainsKey(tipo))
            {
                inventarioGranos[tipo] -= cantidad;
                if (inventarioGranos[tipo] <= 0)
                    inventarioGranos.Remove(tipo);
            }
        }

        public int ObtenerStockGrano(string tipo)
        {
            return inventarioGranos.ContainsKey(tipo) ? inventarioGranos[tipo] : 0;
        }

        public Dictionary<string, int> ObtenerTodosLosGranos()
        {
            return new Dictionary<string, int>(inventarioGranos);
        }

        // ============================================================
        // Sección: GESTIÓN DE PRODUCTOS TERMINADOS
        // ============================================================
        public void AgregarProducto(Producto producto)
        {
            if (inventarioProductos.ContainsKey(producto.Nombre))
                inventarioProductos[producto.Nombre] += producto.Cantidad;
            else
                inventarioProductos[producto.Nombre] = producto.Cantidad;
        }

        public void QuitarProducto(string nombre, int cantidad)
        {
            if (inventarioProductos.ContainsKey(nombre))
            {
                inventarioProductos[nombre] -= cantidad;
                if (inventarioProductos[nombre] <= 0)
                    inventarioProductos.Remove(nombre);
            }
        }

        public int ObtenerStockProducto(string nombre)
        {
            return inventarioProductos.ContainsKey(nombre) ? inventarioProductos[nombre] : 0;
        }

        public Dictionary<string, int> ObtenerTodosLosProductos()
        {
            return new Dictionary<string, int>(inventarioProductos);
        }

        // ============================================================
        // Métodos auxiliares
        // ============================================================
        public void LimpiarInventario()
        {
            inventarioGranos.Clear();
            inventarioProductos.Clear();
        }
    }
}
