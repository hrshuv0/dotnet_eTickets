using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eTickets.Data.Enums;


namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string ImageUrl { get; set; }
        
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }
        
        [Display(Name = "Select a actor('s)")]
        [Required(ErrorMessage = "Movie actor('s) is required")]
        public List<int> ActorIds { get; set; }
        
        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }
        
        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
        
        
    }
}