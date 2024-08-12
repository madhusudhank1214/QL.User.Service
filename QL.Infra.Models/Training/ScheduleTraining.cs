using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class ScheduleTraining
    {
        
        public string Topic { get; set; }
        public string LearningObjectives { get; set; }
        public string FocusAreas { get; set; }

        public string Mode { get; set; }
        public string Venuduration { get; set; }
        public string Facilitator { get; set; }
        public bool IsAttended { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TrCode { get; set; }
    }
        
}
