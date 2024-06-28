using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class RequestsDto
    {
        public int Sl_no { get; set; }

        public string Project { get; set; }

        public DateTime Requested_date { get; set; }

        private DateTime? approveddate = null;
        public DateTime? Approved_date
        {
            get
            {
                return approveddate.HasValue
                   ? this.approveddate.Value
                   : null;
            }

            set { this.approveddate = value; }
        }

        public string Approver { get; set; }

        public string Status {  get; set; }

        public string Comments { get; set; }

        public int NoOfDays { get; set; }

        public string Emp_id { get; set; }

        public Guid Req_id { get; set; }
    }
}
