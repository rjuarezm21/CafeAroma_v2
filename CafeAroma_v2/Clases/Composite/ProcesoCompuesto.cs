using System.Collections.Generic;

namespace CafeAroma_v2.Clases.Composite
{
    public class ProcesoCompuesto : IProceso
    {
        private readonly List<IProceso> _procesos = new List<IProceso>();
        public void Agregar(IProceso proceso) => _procesos.Add(proceso);
        public void Ejecutar()
        {
            foreach (var p in _procesos) p.Ejecutar();
        }
    }
}
