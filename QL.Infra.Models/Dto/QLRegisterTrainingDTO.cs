using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class QLRegisterTrainingDTO
    {
        public string EmpId { get; set; }
        public string ManagerId { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsAttended { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
