using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class GestionEmpleado
    {
        public string Id { get; set; } = null!;
        public string ProyectoId { get; set; } = null!;
        public string PersonasId { get; set; } = null!;

        public virtual Persona Personas { get; set; } = null!;
        public virtual Proyecto Proyecto { get; set; } = null!;
    }
}
