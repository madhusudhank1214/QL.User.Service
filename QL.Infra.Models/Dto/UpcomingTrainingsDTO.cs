﻿namespace QL.Infra.Models.Dto
{
    public class UpcomingTrainingsDTO
    {
        public string Topic { get; set; }
        public Guid TrainingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TutorName { get; set; }
        public string VirtualOrInternal { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string VenuDuration { get; set; }
        public string RegistrationStatus { get; set; }
    }
}
