using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdoptMe1.Models
{
    public class Login 
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public bool isAdmin { get; set; }

    }
}
