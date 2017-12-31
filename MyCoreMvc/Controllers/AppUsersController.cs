using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;
using MyCoreMvc.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly UserManager<AppUser> appUserManager;

        private readonly SignInManager<AppUser> signInManager;

        public AppUsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.appUserManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Register(RegistrationParams registrationParams)
        {
            if (registrationParams.Password != registrationParams.RetypedPassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return View();
            }

            AppUser newUser = new AppUser
            {
                UserName = registrationParams.Email,
                Email = registrationParams.Email
            };

            var userCreationResult = await appUserManager.CreateAsync(newUser, registrationParams.Password);
            if (!userCreationResult.Succeeded)
            {
                foreach (var error in userCreationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            //await appUserManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Role, "Administrator"));
            
            string emailConfirmationToken = await appUserManager.GenerateEmailConfirmationTokenAsync(newUser);

            string tokenVerificationUrl = Url.Action("VerifyEmail", "AppUsers", new { id = newUser.Id, token = emailConfirmationToken }, Request.Scheme);

            LocalEmailClient.SendEmail("email confirmation", "AppUser", "Register", tokenVerificationUrl);
            //await _messageService.Send(email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            //return Content("Check your email for a verification link");

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            var user = await appUserManager.FindByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException();

            var emailConfirmationResult = await appUserManager.ConfirmEmailAsync(user, token);
            if (!emailConfirmationResult.Succeeded)
                return Content(emailConfirmationResult.Errors.Select(error => error.Description).Aggregate((allErrors, error) => allErrors += ", " + error));

            //return Content("Email confirmed, you can now log in");
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ViewResult Index() => View(appUserManager.Users);

        //Register (sign-up form)
        //Register (create user)
        //Verify Email

        //Forgot password (request reset form)
        //Forgot password (create reset email)
        //ResetPassword (reset password form)
        //ResetPassword (update user password)

        //new

        //create

        //show

        //edit

        //update

        [HttpPost("[controller]/{id}/delete")]
        public async Task<IActionResult> Destroy(string id)
        {
            AppUser user = await appUserManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await appUserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", appUserManager.Users);
        }
    }
}

//source: http://www.blinkingcaret.com/2016/11/30/asp-net-identity-core-from-scratch/
//source: https://github.com/ruidfigueiredo/AspNetIdentityFromScratch/blob/master/Controllers/AccountController.cs

//Login (sign-in form)
//Login (create user session)
