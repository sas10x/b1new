using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Role { get; set; }
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}