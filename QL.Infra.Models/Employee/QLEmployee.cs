using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class QLEmployee
    {
        public required string EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int RoleId { get; set; }
        public int ProjectId { get; set; }
        public int MobileNumber { get; set; }

        public string RoleName { get; set; }
        public string ProjectName { get; set; }
    }
}
