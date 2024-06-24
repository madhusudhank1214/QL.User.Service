using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ProjectID { get; set; }

        public int PermissionId { get; set; }

        public int Appid { get; set; }
    }
}
