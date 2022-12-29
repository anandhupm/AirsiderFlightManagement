using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AirsiderFlightManagement.Models
{
    public class Passenger : IdentityUser
    {
        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
    }
}
