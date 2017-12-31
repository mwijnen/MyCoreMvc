using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }

        public bool AdditionalParameter { get; set; }
    }
}
