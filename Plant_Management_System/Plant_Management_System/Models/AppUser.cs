using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName()
        {
            return string.IsNullOrWhiteSpace(FirstName + " " + LastName) ? this.UserName : (FirstName + " " + LastName).Trim();
        }
    }
}
