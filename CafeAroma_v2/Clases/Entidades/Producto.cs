namespace CafeAroma_v2.Clases.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdGrano { get; set; }   
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }

        public Producto(string nombre, int idGrano, int cantidad, decimal precio)
        {
            Nombre = nombre;
            IdGrano = idGrano;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
