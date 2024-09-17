using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class FilterRequest
    {
        public string? EmpName {  get; set; }
        public string? EmpMail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Topic { get; set; }
        public string? Facilitator { get; set; }
        public bool? IsVirtual { get; set; }
        public bool? IsInternal { get; set; }
    }
}
