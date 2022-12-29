using Microsoft.VisualBasic;

namespace AirsiderFlightManagement.Models
{
    public enum Location
    {
        Kochi,
        Thiruvananthapuram,
        KozhiKode,
        Kannur,
        Mumbai,
        Chennai,
        Delhi,
        Dubai,
        Doha,
        Beijing,
        Tokyo,
        Abudhabi

    }


    public class FlightSchedule
    {
        public long  Id { get; set; }
        public Location FlightFrom { get; set; }

        public Location FlightTo { get; set;}

        public DateTime FlightDate { get; set; }

        public int Cost { get; set; }

        public Flight Flight { get; set; }

        public long FlightId { get; set; }


    }
}
