using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Error
    {
        public string Identificador { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? NumSerieServidor { get; set; }
        public string? CodAplicacion { get; set; }
        public string Impacto { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string? ProyectoId { get; set; }

        public virtual Software? CodAplicacionNavigation { get; set; }
        public virtual Software? NumSerieServidorNavigation { get; set; }
        public virtual ProyectoError? Proyecto { get; set; }
        public virtual ProyectoError ProyectoError { get; set; } = null!;
    }
}
