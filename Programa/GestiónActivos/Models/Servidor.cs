using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Servidor
    {
        public Servidor()
        {
            SoftwareServidores = new HashSet<SoftwareServidore>();
        }

        public string NumeroSerie { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Memoria { get; set; } = null!;
        public string CapacidadAlmacenamiento { get; set; } = null!;
        public string CapacidadProcesamiento { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateTime FechaCompra { get; set; }
        public string CodAplicaciones { get; set; } = null!;

        public virtual ICollection<SoftwareServidore> SoftwareServidores { get; set; }
    }
}
