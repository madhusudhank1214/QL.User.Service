namespace QL.Infra.Models.Dto
{
    public class CompletedTrainingsDTO
    {
        public string Topic { get; set; }
        public Guid TrainingId { get; set; }
        public string TutorName { get; set; }
        public DateTime CompletedOn { get; set; }
        public string VirtualOrInternal { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string VenuDuration { get; set; }
    }
}
