using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class Notifications
    {
        public required string NotificationId { get; set; }
        public string Title { get; set; }
        public string NotificationStatus { get; set; }
        private DateTime? createdDate = null;
        public DateTime CreatedDate
        {
            get
            {

                return createdDate.HasValue
                   ? this.createdDate.Value
                   : DateTime.Now;
            }

            set { this.createdDate = value; }
        }
        public DateTime? ApprovedDate { get; set; }
        public required string RequestId { get; set; }

        public bool Read {  get; set; }

        public string RejectedReason { get; set; }


    }
}
