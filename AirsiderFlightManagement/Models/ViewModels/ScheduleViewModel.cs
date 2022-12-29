namespace AirsiderFlightManagement.Models.ViewModels
{
    public class ScheduleViewModel
    {
        [Display(Name ="Starting Point")]
        public Location FlightFrom { get; set; }

        
        [Display(Name = "Destination")]
        public Location FlightTo { get; set; }

        [Display(Name = "Date")]

        public DateTime FlightDate { get; set; }

        public int Cost { get; set; }

        public long Flight { get; set; }
        public IEnumerable<Flight>? Flights { get; set; }

    }
}
