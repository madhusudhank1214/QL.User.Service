﻿namespace QL.Infra.Models.Dto
{
    public class PendingApprovalsDTO
    {
        public Guid TrainingId { get; set; }
        public string Topic { get; set; }
        public string EmpName { get; set; }
        public string ManagerName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string duration { get; set; }
        public string Venuduration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; }
        public string Trainer { get; set; }
        public string? VirtualOrInternal { get; set; }
        public bool? IsBuheadApproval { get; set; }
        public string EmpMail { get; set; }
    }
}
