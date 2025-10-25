using System.Collections.Generic;
namespace CafeAroma_v2.Clases.Command { public class Invoker { private Stack<ICommand> historial = new Stack<ICommand>(); public void Ejecutar(ICommand cmd) { cmd.Ejecutar(); historial.Push(cmd); } public void Deshacer() { if (historial.Count == 0) return; var c = historial.Pop(); c.Deshacer(); } } }
