namespace CafeAroma_v2.Clases.Strategy
{
    public class ContextoDistribucion
    {
        private IDistribucion _estrategia;
        public void SetEstrategia(IDistribucion e) => _estrategia = e;
        public void Ejecutar() => _estrategia?.EntregarPedido();
    }
}
