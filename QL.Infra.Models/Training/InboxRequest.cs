using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class InboxRequest
    {
        public bool IsAdmin { get; set; }
        public bool IsEmployee { get; set; }
        public string? EmpMail { get; set; }
        public bool IsManager { get; set; }
        public bool IsBUHead { get; set; }
        public string? ManagerEmail { get; set; }
    }

}
