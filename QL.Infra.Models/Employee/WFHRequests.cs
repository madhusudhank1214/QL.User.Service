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
        public string? Status { get; set; }
        public string? Comments { get; set; }
        public int No_Of_Days { get; set; }

        private DateTime? requestDate = null;
        public DateTime RequestDate
        {
            get
            {
                return requestDate.HasValue
                   ? this.requestDate.Value
                   : DateTime.Now;
            }

            set { this.requestDate = value; }
        }

        private DateTime? fromDate = null;
        public DateTime FromDate
        {
            get
            {
                return fromDate.HasValue
                   ? this.fromDate.Value
                   : DateTime.Now;
            }

            set { this.fromDate = value; }
        }
        public DateTime ToDate { get; set; }
        public DateTime Approved_Date { get; set; }
    }
}
