using System;

namespace CafeAroma_v2.Clases.Entidades
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
