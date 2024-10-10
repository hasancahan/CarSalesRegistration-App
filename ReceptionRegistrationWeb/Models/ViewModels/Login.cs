using System.ComponentModel.DataAnnotations;

namespace ReceptionRegistrationWeb.Models.ViewModels
{
    public class Login
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
