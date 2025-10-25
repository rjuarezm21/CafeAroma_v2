using System;

namespace CafeAroma_v2.Clases.Observer
{
    public class ObservadorReportes : IObservador
    {
        public void Actualizar(string mensaje)
        {
            Console.WriteLine($"[Reportes] Nueva notificación recibida: {mensaje}");
            // Aquí puedes agregar código para generar o actualizar un reporte en tiempo real
        }
    }
}
