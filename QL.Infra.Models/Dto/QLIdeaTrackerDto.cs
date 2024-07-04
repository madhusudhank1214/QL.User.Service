using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class QLIdeaTrackerDto
    {
        public int Sl_no { get; set; }
        public string Title { get; set; }
        public string Idea_description { get; set; }
        public string Idea_type { get; set; }
        public string Benefits { get; set; }
        public string Technology { get; set; }
        public int Estimated_effort { get; set; }
        public int Actual_affort { get; set; }
        public int Annual_saving { get; set; }
        public int Status { get; set; } 
        public string Resource_name { get; set; }
    }
}
