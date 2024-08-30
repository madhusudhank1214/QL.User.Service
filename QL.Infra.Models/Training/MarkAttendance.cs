namespace QL.Infra.Models.Training
{
    public class MarkAttendance
    {
        public string empMail { get; set; }
        public bool isAttended { get; set; }
        public Guid trainingScheduleId { get; set; }
    }
}
