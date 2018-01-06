using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;
using MyCoreMvc.Utilities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account", new { ReturnUrl = returnUrl });
            AuthenticationProperties properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<ActionResult> GoogleResponse(string returnUrl = "/")
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
                };
                IdentityResult identityResult = await userManager.CreateAsync(user);
                if (identityResult.Succeeded)
                {
                    identityResult = await userManager.AddLoginAsync(user, info);
                    if (identityResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return Redirect(returnUrl);
                    }
                }
                return Redirect("/");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View("Form", new Registration());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Registration registrationParams)
        {
            if (registrationParams.Password != registrationParams.RetypedPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords don't match");
                return View("Register", registrationParams);
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
                return View("Register", registrationParams);
            }

            await userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Role, "ApplicationUser"));

            string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string tokenVerificationUrl = Url.Action("VerifyEmail", "Registrations", new { id = newUser.Id, token = emailConfirmationToken }, Request.Scheme);

            LocalEmailClient.SendEmail("email confirmation", "Account", "VerifyEmail", tokenVerificationUrl);
            //await _messageService.Send(email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            //return Content("Check your email for a verification link");

            return RedirectToAction(actionName: "Index", controllerName: "Users");
        }

        [AllowAnonymous]
        [HttpGet]
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string redirectUrl = null)
        {
            return View("Login", new Session() { RedirectUrl = redirectUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Session session)
        {
            var user = await userManager.FindByEmailAsync(session.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View("Login", session);
            }
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Confirm your email first");
                return View("Login");
            }

            Microsoft.AspNetCore.Identity.SignInResult passwordSignInResult = await signInManager.PasswordSignInAsync(user,
                session.Password, isPersistent: session.RememberMe, lockoutOnFailure: false);

            if (!passwordSignInResult.Succeeded)
            {
                await userManager.AccessFailedAsync(user);
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View("Login", session);
            }

            if (session.RedirectUrl != null)
            {
                return Redirect(session.RedirectUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPassword", new ResetPassword());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return Content("Check your email for a password reset link");

            var passwordResetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetUrl = Url.Action("ResetPassword", "Account", new { id = user.Id, token = passwordResetToken }, Request.Scheme);

            LocalEmailClient.SendEmail("reset password", "Account", "ResetPassword", passwordResetUrl);
            //await _messageService.Send(email, "Password reset", $"Click <a href=\"" + passwordResetUrl + "\">here</a> to reset your password"); 

            //return Content("Check your email for a password reset link");

            return RedirectToAction(actionName: "Login", controllerName: "Account");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword(string id, string token)
        {
            return View("ResetPassword");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var user = await userManager.FindByIdAsync(resetPassword.Id);
            if (user == null)
                throw new InvalidOperationException();

            if (resetPassword.Password != resetPassword.Repassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match");
                return View();
            }

            var resetPasswordResult = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPasswordResult.Succeeded)
            {


                foreach (var error in resetPasswordResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            //return Content("Password updated");
            return RedirectToAction(actionName: "Login", controllerName: "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

//966835248687-mlneuvlvmq5igl83rv5p9h405fv4c42k.apps.googleusercontent.com
//source: https://github.com/ruidfigueiredo/AspNetIdentityFromScratch/blob/master/Controllers/AccountController.cs
