using ServiceStack;
using ServiceStack.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.ServiceModel.Requests.ToDoRequests;
using ToDoTask.ServiceModel.Types;

namespace ToDoTask.ServiceModel.Validators
{
    public class ToDoValidator  : AbstractValidator<ToDoCreateRequest>
    {
        public ToDoValidator()
        {

            RuleSet(ApplyTo.Post ,() =>
            {
                RuleFor(req => req.Title).NotEmpty();
                RuleFor(req => req.Description).NotEmpty();
                RuleFor(req => req.TimeOfExpiry).NotEmpty().GreaterThan(DateTime.Now);
                RuleFor(req => req.Complete).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);               
            });
        }
    }
}
