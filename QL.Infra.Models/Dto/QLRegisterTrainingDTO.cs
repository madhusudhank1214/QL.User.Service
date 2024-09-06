namespace QL.Infra.Models.Dto
{
    public class QLRegisterTrainingDTO
    {
        public string EmpMail { get; set; }
        public string ManagerMail { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public string EmpName { get; set; }
        public string ManagerName { get; set; }

        public string BuHeadMail { get; set; }

    }
}
