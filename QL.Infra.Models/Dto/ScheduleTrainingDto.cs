using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class ScheduleTrainingDTO
    {
		public int Id { get; set; }
        public Guid TrainingId { get; set; }
        public string Topic { get; set; }
        public string LearningObjectives { get; set; }
        public string FocusAreas { get; set; }
        public string Mode { get; set; }
		public string VenuDuration { get; set; }
        public string Facilitator { get; set; }
        public bool IsCancelled { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
		public string Link { get; set; }
        public bool IsBUHeadApproval { get; set; }
        public bool IsInternal { get; set; }
        public bool IsVirtual { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
