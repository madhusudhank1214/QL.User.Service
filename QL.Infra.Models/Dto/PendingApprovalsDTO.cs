namespace QL.Infra.Models.Dto
{
    public class PendingApprovalsDTO
    {
        public Guid TrainingId { get; set; }
        public string Topic { get; set; }
        public string EmpName { get; set; }
        public string ManagerName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCancelled { get; set; }
    }
}
