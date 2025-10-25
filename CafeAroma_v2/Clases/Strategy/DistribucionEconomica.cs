using System;

namespace CafeAroma_v2.Clases.Strategy
{
    public class DistribucionEconomica : IDistribucion
    {
        public void EntregarPedido() => Console.WriteLine("Entrega económica en 3-5 días.");
    }
}
