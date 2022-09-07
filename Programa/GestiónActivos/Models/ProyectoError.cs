using System;
using System.Collections.Generic;

namespace GestiónActivos.Models
{
    public partial class ProyectoError
    {
        public ProyectoError()
        {
            Errors = new HashSet<Error>();
        }

        public string ProyectoId { get; set; } = null!;
        public string ErrorId { get; set; } = null!;

        public virtual Error Error { get; set; } = null!;
        public virtual Proyecto Proyecto { get; set; } = null!;
        public virtual ICollection<Error> Errors { get; set; }
    }
}
