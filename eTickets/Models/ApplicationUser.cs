using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        
        
    }
}