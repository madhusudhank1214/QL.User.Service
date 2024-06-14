using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class WFHRequests
    {
        public required string RequestId { get; set; }
        public required string EmployeeId { get; set; }
        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string? Status { get; set; }
        public string? Comments { get; set; }
        public int No_Of_Days { get; set; }
        public DateTime Approved_Date { get; set; }
    }
}
