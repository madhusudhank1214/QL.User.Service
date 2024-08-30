using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QL.Infra.Models.Dto
{
    public class QLTrainingRegistrationDto
    {
        public string EmpMail {  get; set; }
        public string EmpName { get; set; }
        public string ManagerMail { get; set; }        
        public string TOPIC { get; set; }
        public string Facilitator { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsAttended { get; set; }
        public bool Iscancelled { get; set; }
        public Guid TrainingScheduleId {  get; set; }
	   
    }
}
