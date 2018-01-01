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
        public ViewResult Index() => View();
    }
}
