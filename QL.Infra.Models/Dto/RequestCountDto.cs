using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class RequestCountDto
    {
        public int TotalRequestCount { get; set; }
        public int ApprovedRequestCount { get; set; }
        public int RejectedRequestsCount { get; set; }
        public int CreatedRequestsCount { get; set; }
    }
}