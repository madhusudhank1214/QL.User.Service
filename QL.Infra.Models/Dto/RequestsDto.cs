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

        public DateTime Approved_date { get; set; }

        public string Approver { get; set; }

        public string Status {  get; set; }

        public string Comments { get; set; }

        public int NoOfDays { get; set; }
    }
}
