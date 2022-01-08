using ServiceStack;
using ServiceStack.FluentValidation;
using ToDoTask.ServiceModel.Requests.ToDoRequests;

namespace ToDoTask.ServiceModel.Validators
{
    public class ToDoUpdatePercentValidator : AbstractValidator<ToDoUpdatePercentRequest>
    {
        public ToDoUpdatePercentValidator()
        {

            RuleSet(ApplyTo.Put, () =>
            {
                RuleFor(req => req.Complete).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            });
        }
    }
}
