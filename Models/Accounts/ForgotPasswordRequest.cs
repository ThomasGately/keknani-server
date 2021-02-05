using System.ComponentModel.DataAnnotations;

namespace keknani_server.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}