using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Authentication
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
