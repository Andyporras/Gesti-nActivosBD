using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class Software
    {
        public Software()
        {
            ErrorCodAplicacionNavigations = new HashSet<Error>();
            ErrorNumSerieServidorNavigations = new HashSet<Error>();
            SoftwareServidoreCodAplicacionNavigations = new HashSet<SoftwareServidore>();
            SoftwareServidoreNumSerieServidorNavigations = new HashSet<SoftwareServidore>();
            CodDepartamentos = new HashSet<Departamento>();
        }

        public string Codigo { get; set; } = null!;
        public string NumeroPatente { get; set; } = null!;
        public string NumSerieServidor { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string CodDepartamento { get; set; } = null!;

        public virtual ICollection<Error> ErrorCodAplicacionNavigations { get; set; }
        public virtual ICollection<Error> ErrorNumSerieServidorNavigations { get; set; }
        public virtual ICollection<SoftwareServidore> SoftwareServidoreCodAplicacionNavigations { get; set; }
        public virtual ICollection<SoftwareServidore> SoftwareServidoreNumSerieServidorNavigations { get; set; }

        public virtual ICollection<Departamento> CodDepartamentos { get; set; }
    }
}
