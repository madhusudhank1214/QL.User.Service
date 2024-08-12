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
            RuleFor(schedule => schedule).NotEmpty();
        //        .Must(x => x.EndDate == default(DateTime) || x.StartDate == default(DateTime) || x.EndDate >= x.StartDate)
        //.WithMessage("EndDate must greater than equal  StarDate");

        }
    }
}
