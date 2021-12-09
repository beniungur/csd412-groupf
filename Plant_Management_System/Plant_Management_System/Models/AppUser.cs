using Microsoft.AspNetCore.Identity;

// The app user class stores the registered users
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
