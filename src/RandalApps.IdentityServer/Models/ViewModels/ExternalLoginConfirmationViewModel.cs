using System.ComponentModel.DataAnnotations;

namespace RandalApps.IdentityServer.Models.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
