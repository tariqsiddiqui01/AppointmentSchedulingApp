using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulingApp.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DisplayName("Remember Me?")]
        public bool RememberMe { get; set; }

    }
}