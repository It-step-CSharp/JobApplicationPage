using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobApplication.Models
{
    public class JobApplicationViewModel
    {
        [Required, StringLength(45), Display(Name = "First name *")]
        public string FirtsName { get; set; }

        [Required, StringLength(45), Display(Name = "Last name *")]
        public string LastName { get; set; }

        [Range(0, 50), Display(Name = "Years of experience *")]
        public int YearsOfExperiance  { get; set; }

        [Required, Display(Name = "Please select a position *")]
        public Position Position { get; set; }

        [Required, Display(Name = "Your email *")]
        public string Email { get; set; }

        [Display(Name = "Short description")]
        public string Description { get; set; }

        [Required ,Display(Name = "Attach a CV *")]
        public IFormFile CV { get; set; }
    }
}
