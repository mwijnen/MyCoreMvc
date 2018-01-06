using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class Registration
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RetypedPassword { get; set; }

        public string RedirectUrl { get; set; }
    }
}
