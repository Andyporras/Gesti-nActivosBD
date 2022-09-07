using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Persona
    {
        public Persona()
        {
            GestionEmpleados = new HashSet<GestionEmpleado>();
            CodDepartamentos = new HashSet<Departamento>();
        }

        public string Cedula { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Rol { get; set; } = null!;

        public virtual ICollection<GestionEmpleado> GestionEmpleados { get; set; }

        public virtual ICollection<Departamento> CodDepartamentos { get; set; }
    }
}
