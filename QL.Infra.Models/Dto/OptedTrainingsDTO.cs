namespace QL.Infra.Models.Dto
{
    public class OptedTrainingsDTO
    {
        public string Topic { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public string TutorName { get; set; }
        public string VirtualOrInternal { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string VenuDuration { get; set; }
    }
}
