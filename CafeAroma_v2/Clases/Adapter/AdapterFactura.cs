namespace CafeAroma_v2.Clases.Adapter
{
    public class SistemaFacturaExterno { public bool EnviarFactura(string datos) { System.Diagnostics.Debug.WriteLine("Factura enviada: " + datos); return true; } }
    public interface IFacturaAdapter { bool Enviar(string datos); }
    public class AdapterFactura : IFacturaAdapter { private SistemaFacturaExterno ext = new SistemaFacturaExterno(); public bool Enviar(string d) => ext.EnviarFactura(d); }
}
