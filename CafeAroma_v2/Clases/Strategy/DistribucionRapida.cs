using System;

namespace CafeAroma_v2.Clases.Strategy
{
    public class DistribucionRapida : IDistribucion
    {
        public void EntregarPedido() => Console.WriteLine("Entrega rápida en 24 horas.");
    }
}
