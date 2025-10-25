using System.Collections.Generic;

namespace CafeAroma_v2.Clases.Command
{
    /// <summary>
    /// Clase responsable de ejecutar comandos, almacenar su historial
    /// y permitir deshacer la última acción realizada.
    /// </summary>
    public class GestorDeComandos
    {
        // Pila para mantener el historial de comandos ejecutados
        private readonly Stack<ICommand> historial = new Stack<ICommand>();

        /// <summary>
        /// Ejecuta un comando y lo agrega al historial.
        /// </summary>
        /// <param name="comando">Comando que implementa la interfaz ICommand</param>
        public void EjecutarComando(ICommand comando)
        {
            comando.Ejecutar();
            historial.Push(comando);
        }

        /// <summary>
        /// Deshace el último comando ejecutado si hay alguno en el historial.
        /// </summary>
        public void Deshacer()
        {
            if (historial.Count > 0)
            {
                ICommand comando = historial.Pop();
                comando.Deshacer();
            }
        }

        /// <summary>
        /// Limpia todo el historial de comandos.
        /// </summary>
        public void LimpiarHistorial()
        {
            historial.Clear();
        }
    }
}
