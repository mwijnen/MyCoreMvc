using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base() { }

        public bool AdditionalParameter { get; set; }
    }
}
