using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class TrainingAttendanceRecordsDto
    {
        public Guid TrainingID { get; set; }

        public string EmailAddress { get; set; }
        public bool IsAttended { get; set; }

        public string Comments { get; set; }
    }
}
