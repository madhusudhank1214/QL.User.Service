﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class ScheduleTraining
    {
        public Guid? TrainingID {  get; set; }
        public string Topic { get; set; }
        public string LearningObjectives { get; set; }
        public string FocusAreas { get; set; }

        public string Mode { get; set; }
        public string Venuduration { get; set; }
        public string Facilitator { get; set; }
        public string IsCancelled{ get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }        
        public string IsBuHeadApproval { get; set; }
        public string IsInternal { get; set; }
        public string IsVirtual { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string IsMandatory { get; set; }
        public int Occurence { get; set; }

    }
        
}
