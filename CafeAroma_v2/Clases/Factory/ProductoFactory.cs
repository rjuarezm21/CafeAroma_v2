namespace CafeAroma_v2.Clases.Factory
{
    public static class ProductoFactory
    {
        public static ProductoCafe CrearCafe(string tipo)
        {
            switch (tipo)
            {
                case "Arabica": return new Arabica() { Nombre = "Arábica" };
                case "Robusta": return new Robusta() { Nombre = "Robusta" };
                default: return new Blend() { Nombre = "Blend" };
            }
        }
    }
}
