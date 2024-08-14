using FluentValidation;
using QL.Infra.Models.Training;
using System;

namespace UserService.API.Validators
{
    public class ScheduleTrainingValidator : AbstractValidator<ScheduleTraining>
    {
        public ScheduleTrainingValidator()
        {
            RuleFor(schedule => schedule.Topic).NotEmpty();
            RuleFor(schedule => schedule.Facilitator).NotEmpty();
            RuleFor(schedule => schedule.Venuduration).NotEmpty();
            RuleFor(schedule => schedule.FocusAreas).NotEmpty();
            RuleFor(schedule => schedule.LearningObjectives).NotEmpty();
            RuleFor(schedule => schedule.StartDate).NotEmpty();
            RuleFor(schedule => schedule.EndDate).NotEmpty();
            RuleFor(schedule => schedule.LearningObjectives).NotEmpty();
            RuleFor(schedule => schedule.Mode).NotEmpty();
            RuleFor(schedule => schedule.IsCancelled).NotEmpty();
            RuleFor(schedule => schedule.IsBuHeadApproval).NotEmpty();
            RuleFor(schedule => schedule.IsInternal).NotEmpty();
            RuleFor(schedule => schedule.IsVirtual).NotEmpty();

        }
    }
}
