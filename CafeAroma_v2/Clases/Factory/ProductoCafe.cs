namespace CafeAroma_v2.Clases.Factory
{
    public abstract class ProductoCafe
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public abstract string ObtenerDescripcion();
    }
}
