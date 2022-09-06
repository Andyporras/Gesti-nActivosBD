namespace GestiónActivos.Models{
    public class proyecto{
        public string? esfuerzoReal { get; set; }
        public string? esfuerzoEstimado { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? identificador { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFinal { get; set; }
    }
}
