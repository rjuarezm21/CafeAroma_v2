namespace CafeAroma_v2.Clases.Observer
{
    public interface ISujeto
    {
        void Registrar(IObservador observador);
        void Remover(IObservador observador);
        void Notificar(string mensaje);
    }
}
