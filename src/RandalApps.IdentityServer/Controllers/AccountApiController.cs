using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using RandalApps.IdentityServer.Models.Account;
using RandalApps.IdentityServer.Models.Common;
using RandalApps.IdentityServer.Models.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Controllers
{
    [Route("api/account")]
    public class AccountApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AccountApiController(
             UserManager<ApplicationUser> userManager,
             ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<AccountApiController>();
        }

        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "Accounts service is online.";
        }

        //
        // POST: /api/account/register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<RegistrationResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            var result = new RegistrationResult();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };                
                var identityResult = await _userManager.CreateAsync(user, model.Password);

                var claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Email, model.Email.Trim('\n')),
                    new Claim(JwtClaimTypes.GivenName, model.FirstName.Trim('\n')),
                    new Claim(JwtClaimTypes.FamilyName, model.LastName.Trim('\n')),
                    new Claim(JwtClaimTypes.MiddleName, model.MiddleName.Trim('\n'))
                };

                await _userManager.AddClaimsAsync(user, claims);

                if (identityResult.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                    _logger.LogInformation(3, "User created a new account with password.");

                    result.IsSuccess = true;
                }
                else
                {
                    AddErrors(identityResult, result);
                }
            }

            foreach (var error in from x in ModelState.Values
                                where x.ValidationState == ModelValidationState.Invalid
                                from err in x.Errors
                                select err)
            {
                result.Errors.Add(new Error(error.ErrorMessage));
            }

            return result;
        }

        private void AddErrors(IdentityResult result, RegistrationResult registrationResult)
        {
            foreach (var error in result.Errors)
            {
                if (error.Code == "DuplicateUserName")
                {
                    registrationResult.Errors.Add(new Error(error.Description, "username"));
                }
                else
                {
                    registrationResult.Errors.Add(new Error(error.Description));
                }
            }
        }
    }
}
