using System;
using FluentValidation;

namespace Swagon.DataBase
{
    public class BasicStringValidations : AbstractValidator<String>
    {
        public BasicStringValidations()
        {
            RuleSet("EmptyString", () =>
            {
               RuleFor(x => x).NotEmpty().WithMessage("string is empty"); 
            });
        }
    }
}
