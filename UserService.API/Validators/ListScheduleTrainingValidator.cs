using FluentValidation;
using QL.Infra.Models.Training;

namespace UserService.API.Validators
{
    public class ListScheduleTrainingValidator : AbstractValidator<List<ScheduleTraining>>
    {
        public ListScheduleTrainingValidator() {

            RuleForEach(ScheduleTraining => ScheduleTraining)
             .SetValidator(new ScheduleTrainingValidator());
        }
    }
}
