using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminars.Models.AdminViewModels
{
    public class AddPageViewModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public DateTimeOffset PubDate { get; set; }

        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;

        public int AdminId { get; set; }

        public Status Status { get; set; }

        public List<Category> Categories { get; set; }
    }
}
