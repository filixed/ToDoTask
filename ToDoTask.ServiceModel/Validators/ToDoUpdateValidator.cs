using ServiceStack;
using ServiceStack.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Requests.ToDoRequests;

namespace ToDoTask.ServiceModel.Validators
{
    public class ToDoUpdateValidator : AbstractValidator<ToDoUpdateRequest>
    {
        public ToDoUpdateValidator()
        {

            RuleSet(ApplyTo.Put, () =>
            {
                RuleFor(req => req.Title).NotEmpty();
                RuleFor(req => req.Description).NotEmpty();
                RuleFor(req => req.TimeOfExpiry).NotEmpty().GreaterThan(DateTime.Now);
                RuleFor(req => req.Complete).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            });
        }
    }
}
