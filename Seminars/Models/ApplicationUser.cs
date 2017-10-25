using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Seminars.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string SpeakerName { get; set; }

        public string Bio { get; set; }

        public string Education { get; set; }

        public string Books { get; set; }

        public string Courses { get; set; }

        public string Reviews { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public String Zip { get; set; }

        public string State { get; set; }

        public string ProfileUrl { get; set; }

        public string Featured { get; set; }

        public List<Specialization> Specializations { get; set; }

        public List<Video> Videos { get; set; }

        public List<KeynoteTopic> KeynoteTopics { get; set; }

        public List<BusinessTrainingTopic> BusinessTrainingTopics { get; set; }

        public string AuthorId { get; set; }

        public SpeakerStatus Status { get; set; }
    }

    public enum SpeakerStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
