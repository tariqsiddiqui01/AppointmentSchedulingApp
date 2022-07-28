using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulingApp.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage =" Min 6 Max 100 digits allowed", MinimumLength =6)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage ="Password doesn't match with Confirm  Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        
    }
}