using CafeAroma_v2.Clases.Database;
using CafeAroma_v2.Clases.Entidades;
using CafeAroma_v2.Clases.Singleton;
using System.Collections.Generic;

namespace CafeAroma_v2.Clases.Command
{
    public class AgregarGranoCommand : ICommand
    {
        private readonly Grano g;

        public AgregarGranoCommand(Grano gr) => g = gr;

        public void Ejecutar()
        {
            GestorDelInventario.Instancia.AgregarGrano(g);

            var parametros = new Dictionary<string, object>
            {
                { "@p_tipo", g.Tipo },
                { "@p_origen", g.Origen },
                { "@p_stock", g.Cantidad }
            };

            ConexionBD.Instancia.EjecutarSP("sp_insertar_grano", parametros);
        }

        public void Deshacer()
        {
            GestorDelInventario.Instancia.QuitarGrano(g.Tipo, g.Cantidad);
        }
    }
}
