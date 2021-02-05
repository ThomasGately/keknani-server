using System.ComponentModel.DataAnnotations;

namespace keknani_server.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}