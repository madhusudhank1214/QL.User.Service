using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class QLRegisterTraining
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string ManagerId { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsAttended { get; set; }
        public bool? IsCancelled { get; set; }
        public bool IsManagerApproved { get; set; }
        public bool IsBuHeadApproved { get; set; }
    }
}
