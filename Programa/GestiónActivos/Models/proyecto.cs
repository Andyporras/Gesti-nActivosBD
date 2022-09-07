using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            GestionEmpleados = new HashSet<GestionEmpleado>();
        }

        public string Identificador { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string EsfuerzoEstimado { get; set; } = null!;
        public string EsfuerzoReal { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual ProyectoError ProyectoError { get; set; } = null!;
        public virtual ICollection<GestionEmpleado> GestionEmpleados { get; set; }
    }
}
