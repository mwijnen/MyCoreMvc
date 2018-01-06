using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class ResetPassword
    {
        public string Id { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }

        public string Repassword { get; set; }
    }
}
