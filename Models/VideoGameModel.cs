using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesVideoGameDB.Models
{
    public class VideoGameModel
    {
        public int Id { get; set; }
        [Display(Name = "Game Title")]
        [Required]
        public string GameTitle { get; set; }
        [Display(Name = "Release Year")]
        [Required]
        public string ReleaseYear { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Display(Name = "Complete Copy")]
        [Required]
        public string CompleteCopy { get; set; }
        [Display(Name = "Physical Copy")]
        [Required]
        public string PhysicalCopy { get; set; }
    }
}
