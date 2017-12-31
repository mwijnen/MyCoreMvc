using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;
using Microsoft.AspNetCore.Identity;
using MyCoreMvc.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoreMvc.Controllers
{
    public class RegistrationsController : Controller
    {
        private UserManager<User> userManager;

        public RegistrationsController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        
        [Route("Register")]
        public IActionResult New()
        {
            return View(new Registration());
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Create(Registration registrationParams)
        {
            if (registrationParams.Password != registrationParams.RetypedPassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return View("New", registrationParams);
            }

            User newUser = new User
            {
                UserName = registrationParams.Email,
                Email = registrationParams.Email
            };

            var userCreationResult = await userManager.CreateAsync(newUser, registrationParams.Password);
            if (!userCreationResult.Succeeded)
            {
                foreach (var error in userCreationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("New", registrationParams);
            }

            //await appUserManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Role, "Administrator"));

            string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string tokenVerificationUrl = Url.Action("VerifyEmail", "Registrations", new { id = newUser.Id, token = emailConfirmationToken }, Request.Scheme);

            LocalEmailClient.SendEmail("email confirmation", "Registrations", "Create", tokenVerificationUrl);
            //await _messageService.Send(email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            //return Content("Check your email for a verification link");

            return RedirectToAction(actionName: "Index", controllerName: "Users");
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException();

            var emailConfirmationResult = await userManager.ConfirmEmailAsync(user, token);
            if (!emailConfirmationResult.Succeeded)
                return Content(emailConfirmationResult.Errors.Select(error => error.Description).Aggregate((allErrors, error) => allErrors += ", " + error));

            //return Content("Email confirmed, you can now log in");
            return RedirectToAction(actionName: "Index", controllerName: "Users");
        }

    }
}
