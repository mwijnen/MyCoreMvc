using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MyCoreMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //[AllowAnonymous]
        public ViewResult Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            foreach (string cookieKey in Request.Cookies.Keys)
            {
                cookies.Add(cookieKey, Request.Cookies[cookieKey]);
            }
            if (cookies.Count > 0)
            {
                ViewBag.Cookies = cookies;
            }

            return View();
        }
    }
}
