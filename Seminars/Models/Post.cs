using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminars.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTimeOffset PubDate { get; set; }

        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;

        public string Slug { get; set; }

        public Status Status { get; set; }

        public string Excerpt { get; set; }

        public int ExcerptMaxLength { get; } = 140;

        public List<Tag> Tags { get; set; }

        public List<Category> Categories { get; set; }
    }
}
