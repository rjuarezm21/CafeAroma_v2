using System;

namespace CafeAroma_v2.Clases.Observer
{
    public class ResponsableDeCompras : IObservador
    {
        public void Actualizar(string mensaje)
        {
            Console.WriteLine($"[Compras] Notificación: {mensaje}");
        }
    }
}
