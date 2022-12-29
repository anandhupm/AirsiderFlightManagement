namespace AirsiderFlightManagement.Models.ViewModels
{
    public class FlightRegisterView
    {
        [Required]
        [Display(Name = "Flight Number")]
        public long FlightNumber { get; set; }
        [Required]
        [Display(Name = "Flight Name")]
        public string FlightName { get; set; }
        [Required]
        [Display(Name = "Flight Type")]
        public FlightType FlightType { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Discription { get; set; }
        [Required]
        [Display(Name = "Total Capacity")]
        public int TotalCapacity { get; set; }
    }
}
