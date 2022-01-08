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
    public class ToDoGetOneValidator : AbstractValidator<ToDoGetOneRequest>
    {
        public ToDoGetOneValidator()
        {

            RuleSet(ApplyTo.Get, () =>
            {
                RuleFor(req => req.Id).GreaterThan(0);
            });
        }
    }
}
