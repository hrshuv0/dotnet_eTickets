using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length must be at least 3 ")]
        public string FullName { get; set; }
        
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        
        //Relationships
        public List<ActorMovie> ActorsMovies { get; set; }
        
    }
}