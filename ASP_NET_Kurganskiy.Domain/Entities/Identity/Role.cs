using Microsoft.AspNetCore.Identity;

namespace ASP_NET_Kurganskiy.Domain.Entities.Identity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }


    }
}
