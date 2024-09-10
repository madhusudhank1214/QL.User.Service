using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class QLRegisterTrainingDto
    {
        public Guid TrainingId { get; set; }
        public string TOPIC { get; set; }
        public string Facilitator { get; set; }

        public string FOCUSAREAS { get; set; }
        public string Mode { get; set; }

        public bool TrainingOnLine { get; set; }
        public bool ISCANCELLED { get; set; }
        public bool ISBUHEADAPPROVAL { get; set; }
        public bool ISINTERNAL { get; set; }
        public bool ISVirtual { get; set; }
        public string ApproverId { get; set; }
        public string ApproverName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ISMandatory { get; set; }
        public bool? IsAttended { get; set; }
        public bool IsManagerApproved { get; set; }
        public bool IsBuHeadApproved { get; set; }
    }
}
