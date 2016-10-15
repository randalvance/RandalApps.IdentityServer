using System.ComponentModel.DataAnnotations;

namespace RandalApps.IdentityServer.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
