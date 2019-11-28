using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP_NET_Kurganskiy.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public string Description { get; set; }


    }

    public class Role : IdentityRole
    {
        public string Description { get; set; }


    }
}
