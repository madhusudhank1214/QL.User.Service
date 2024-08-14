using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class QLTrainingsDto
    {
        public Guid TrainingId { get; set; }
        public string TOPIC { get; set; }
        public string Facilitator { get; set; }
        
        public string FOCUSAREAS { get; set; }
        public string Mode { get; set; }
        
        public bool TrainingOnLine { get; set; }
        public bool TrainingInternal { get; set; }
        public bool ApprovalRequired { get; set; }
        public string ApproverId { get; set; }
        public string ApproverName { get; set; }

        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }

    }
}
