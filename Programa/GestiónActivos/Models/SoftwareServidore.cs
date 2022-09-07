using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class SoftwareServidore
    {
        public string CodAplicacion { get; set; } = null!;
        public string NumSerieServidor { get; set; } = null!;
        public string TipoServidor { get; set; } = null!;

        public virtual Software CodAplicacionNavigation { get; set; } = null!;
        public virtual Software NumSerieServidorNavigation { get; set; } = null!;
        public virtual Servidor TipoServidorNavigation { get; set; } = null!;
    }
}
