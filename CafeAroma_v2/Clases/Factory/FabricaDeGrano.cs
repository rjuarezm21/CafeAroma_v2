using CafeAroma_v2.Clases.Entidades;
namespace CafeAroma_v2.Clases.Factory
{
    public static class FabricaDeGrano
    {
        public static Grano Crear(string tipo, int cantidad = 0)
        {
            switch (tipo)
            {
                case "Arábica": return new Grano("Arábica", cantidad, "Alta");
                case "Robusta": return new Grano("Robusta", cantidad, "Estándar");
                default: return new Grano(tipo, cantidad, "Básica");
            }
        }
    }
}
