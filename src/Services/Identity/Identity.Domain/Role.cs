using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public  class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
