using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class RegistrationParams
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RetypedPassword { get; set; }
    }
}
