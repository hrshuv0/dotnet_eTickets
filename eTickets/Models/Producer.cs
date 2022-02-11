using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int ActorId { get; set; }
        
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        
        //Relationships
        public List<Movie> Movies { get; set; }
    }
}