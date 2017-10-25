using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seminars.Models.ManageViewModels
{
    public class SpecializationViewModel
    {
        public List<Topic> Topics { get; set; }

        public List<Specialization> IncludedSpecs { get; set; }

        public List<Topic> ExcludedSpecs { get; set; }

        public ApplicationUser Speaker { get; set; }

        public Guid Sid { get; set; }
    }
}
