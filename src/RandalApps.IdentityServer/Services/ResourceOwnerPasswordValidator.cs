using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using RandalApps.IdentityServer.Models.Identity;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace RandalApps.IdentityServer.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByNameAsync(context.UserName);
            if (user != null)
            {
                if (await _signInManager.CanSignInAsync(user))
                {
                    if (_userManager.SupportsUserLockout &&
                        await _userManager.IsLockedOutAsync(user))
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                    }
                    else if (await _userManager.CheckPasswordAsync(user, context.Password))
                    {
                        if (_userManager.SupportsUserLockout)
                        {
                            await _userManager.ResetAccessFailedCountAsync(user);
                        }

                        var sub = await _userManager.GetUserIdAsync(user);
                        context.Result = new GrantValidationResult(sub, AuthenticationMethods.Password);
                    }
                    else if (_userManager.SupportsUserLockout)
                    {
                        await _userManager.AccessFailedAsync(user);
                    }
                }
            }
        }
    }
}
