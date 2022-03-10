using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class UserRole : IdentityUserRole<string>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
