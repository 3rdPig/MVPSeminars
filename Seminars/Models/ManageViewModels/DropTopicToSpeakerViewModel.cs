using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminars.Models.ManageViewModels
{
    public class DropTopicToSpeakerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid TopicId { get; set; }

        public string SpeakerId { get; set; }
    }
}
