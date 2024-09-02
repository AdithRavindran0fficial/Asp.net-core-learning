using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Login
    {
        [Required]
        public string Email {  get; set; }
        public string Password {  get; set; }
    }
}
