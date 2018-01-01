using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class SessionsController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;
        
        public SessionsController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("Login")]
        public IActionResult New()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            int numberOfCookies = Request.Cookies.Count();
            return View("Form");
        }

        [HttpPost("[controller]/"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Session session)
        {
            var user = await userManager.FindByEmailAsync(session.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View("Form");
            }
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Confirm your email first");
                return View("Form");
            }

            Microsoft.AspNetCore.Identity.SignInResult passwordSignInResult = await signInManager.PasswordSignInAsync(user,
                session.Password, isPersistent: session.RememberMe, lockoutOnFailure: false);

            if (!passwordSignInResult.Succeeded)
            {
                await userManager.AccessFailedAsync(user);
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View("Form");
            }

            return RedirectToAction("Index", "Posts");
        }

        [Route("Logout")]
        public async Task<IActionResult> Destroy()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
