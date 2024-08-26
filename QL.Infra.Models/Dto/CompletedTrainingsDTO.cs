namespace QL.Infra.Models.Dto
{
    public class CompletedTrainingsDTO
    {
        public string Topic { get; set; }
        public DateTime CompletedOn { get; set; }
        public Guid TrainingId { get; set; }
    }
}
