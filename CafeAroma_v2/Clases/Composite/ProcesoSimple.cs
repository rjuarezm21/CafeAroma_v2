using System;

namespace CafeAroma_v2.Clases.Composite
{
    public class ProcesoSimple : IProceso
    {
        private readonly string _nombre;
        public ProcesoSimple(string nombre) { _nombre = nombre; }
        public void Ejecutar() => Console.WriteLine($"Ejecutando proceso: {_nombre}");
    }
}
