using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class ProjectsEmployeeDetailsDto
    {
        public int Sl_no { get; set; }

        public string Emp_id { get; set; }

        public string Email { get; set; }

        public string Project { get; set; }
        public DateTime Allocation_date { get; set; }
        public DateTime End_date { get; set; }
    }
}
