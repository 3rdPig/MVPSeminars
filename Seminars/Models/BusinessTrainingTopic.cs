using System;

namespace Seminars.Models
{
    public class BusinessTrainingTopic
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TopicId { get; set; }

        public string SpeakerId { get; set; }
    }
}