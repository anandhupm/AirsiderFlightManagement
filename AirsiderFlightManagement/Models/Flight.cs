namespace AirsiderFlightManagement.Models
{
    public enum FlightType
    {
        Charted,
        Domestic,
        [Display(Name ="On-Demand")]
        Ondemand,
        International
    }
    public class Flight
    {
        public long FlightId { get; set; }

        public long FlightNumber { get; set; }
        public string FlightName { get; set; }
        public FlightType FlightType { get; set; }

        public string Discription { get; set; }

        public int TotalCapacity { get; set; }
    }

}
