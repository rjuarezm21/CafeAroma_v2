namespace CafeAroma_v2.Clases.Entidades
{
    public class Grano
    {
        public string Tipo { get; set; }
        public string Origen { get; set; }
        public int Cantidad { get; set; }

        // Constructor
        public Grano() { }

        public Grano(string tipo, int cantidad, string origen)
        {
            Tipo = tipo;
            Cantidad = cantidad;
            Origen = origen;
        }
    }
}
