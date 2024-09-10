using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class TrainingAttendanceRecords
    {
        // public int Id { get; set; }

        public Guid TrainingID { get; set; }

        public string EmailAddress { get; set; }

        public DateTime Date { get; set; }

        public bool IsAttended { get; set; }

        public string Comments { get; set; }
    }
}
