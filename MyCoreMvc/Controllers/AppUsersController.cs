using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Controllers
{
    public class AppUsersController : Controller
    {
        private UserManager<AppUser> appUserManager;

        public AppUsersController(UserManager<AppUser> userManager)
        {
            appUserManager = userManager;
        }

        public ViewResult Index() => View(appUserManager.Users);
    }
}
