using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seminars.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Speaker Name")]
        public string SpeakerName { get; set; }

        public string Bio { get; set; }

        public string Education { get; set; }

        public string Books { get; set; }

        public string Courses { get; set; }

        public string Reviews { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ProfilePic { get; set; }

        public string ProfileUrl { get; set; }

        public bool Featured { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
