using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            CedEmpleadosNavigation = new HashSet<Persona>();
            CodAplicacions = new HashSet<Software>();
        }

        public string Codigo { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? JefeCed { get; set; }
        public string? CedEmpleados { get; set; }
        public string? SoftwaresId { get; set; }

        public virtual ICollection<Persona> CedEmpleadosNavigation { get; set; }
        public virtual ICollection<Software> CodAplicacions { get; set; }
    }
}
