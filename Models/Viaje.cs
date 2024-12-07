namespace TaxiApp.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ConductorId { get; set; }
        public DateTime FechaViaje { get; set; }
    }

}
