using CafeAroma_v2.Clases.Database;
using System.Collections.Generic;

namespace CafeAroma_v2.Clases.Observer
{
    public class GestorDeProduccion : ISujeto
    {
        private readonly List<IObservador> observadores = new List<IObservador>();

        public void Registrar(IObservador o) => observadores.Add(o);
        public void Remover(IObservador o) => observadores.Remove(o);

        public void Notificar(string mensaje)
        {
            foreach (var obs in observadores)
                obs.Actualizar(mensaje);

            var parametros = new Dictionary<string, object>
            {
                { "@p_mensaje", mensaje }
            };

            ConexionBD.Instancia.EjecutarSP("sp_insertar_notificacion", parametros);
        }
    }
}
