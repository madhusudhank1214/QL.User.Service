﻿using System;
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public Guid TrCode { get; set; }
    }
        
}
