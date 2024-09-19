using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class InboxResponseDto
    {
        public IEnumerable<UpcomingInboxResponse> UpcomingTrainings { get; set; }
        public IEnumerable<FeedbackInboxResponse> FeedbackTrainings { get; set; }
        public IEnumerable<PendingApprovalsDTO> PendingApprovals { get; set; }
    }

    public class UpcomingInboxResponse
    {
        public Guid TrainingID { get; set; }
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class FeedbackInboxResponse
    {
        public Guid TrainingID { get; set; }
        public string Topic { get; set; }
        public bool IsAttended { get; set; }
        public DateTime CompletedOn { get; set; }
    }    
}
