using System.ComponentModel.DataAnnotations;

namespace AirsiderFlightManagement.Models.ViewModels
{
    public class PassengerRegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(10)]

        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        

    }
}
