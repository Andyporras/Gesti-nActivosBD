namespace GestiónActivos.Models
{
    public class Software {
        public string? codigo { get; set; }
        public int numPatente { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? tipo { get; set; } 
        public DateTime? fechaProduccion { get; set; }
        public DateTime fechaExpiracion { get; set; }

        public void saveSoftware(string pNombre, string pDescripcion){

        }
    }
}
