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
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public ViewResult Index() => View(userManager.Users);
        
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
            User user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
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
            return View("Index", userManager.Users);
        }
    }
}

//source: http://www.blinkingcaret.com/2016/11/30/asp-net-identity-core-from-scratch/
//source: https://github.com/ruidfigueiredo/AspNetIdentityFromScratch/blob/master/Controllers/AccountController.cs

//Login (sign-in form)
//Login (create user session)
