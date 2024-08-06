using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName {  get; set; }
        public string ResourceName { get; set; }
        public int ProjectId { get; set; }
    }
}
