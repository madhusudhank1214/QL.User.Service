using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.InnovateIdea
{
    public class IdeaInfo
    {
        public Guid ID { get; set; }
        public string IdeaName { get; set; }
        public string Status { get; set; }
        public string IdeaDescription { get; set; }
        public string IdeaType { get; set; }
        public string Technology { get; set; }
    }
}
