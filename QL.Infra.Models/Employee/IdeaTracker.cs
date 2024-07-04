using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class IdeaTracker
    {
        public string Title { get; set; }
        public string IdeaDescription { get; set; }
        public string IdeaType { get; set; }
        public string Benefits { get; set; }
        public string Technology { get; set; }
        public int EstimatedEffort { get; set; }
        public int ActualEffort { get; set; }
        public int AnnualSaving { get; set; }
        public string Status { get; set; }
        public string ResourceName { get; set; }
    }
}
