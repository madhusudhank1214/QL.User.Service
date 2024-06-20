using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class Projects
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AllottedDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
