using System;

namespace CafeAroma_v2.Clases.Entidades
{
    public class Lote
    {
        public int IdLote { get; set; }
        public string NumeroLote { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Lote(int idLote, string numeroLote, string estado, DateTime fechaVencimiento)
        {
            IdLote = idLote;
            NumeroLote = numeroLote;
            Estado = estado;
            FechaVencimiento = fechaVencimiento;
        }
    }
}
