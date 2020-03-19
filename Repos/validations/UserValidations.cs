using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Swagon.DataBase.DataModel;

namespace Swagon.DataBase
{
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleSet(RuleSets.User.crentials, () =>
            {
                RuleFor(x => x.Username).Length(3, 50).WithMessage("invalid Username");
                RuleFor(x => x.Password).Length(3, 50).WithMessage("invalid password");
            });
            RuleSet(RuleSets.User.profile, () =>
            {
                RuleFor(x => x.Firstname).NotEmpty().WithMessage("invalid firstname");
                RuleFor(x => x.Lastname).NotEmpty().WithMessage("invalid lastname");
            });
        }
    }

    public class BookingValidations : AbstractValidator<Booking>
    {
        public BookingValidations()
        {
            RuleSet(RuleSets.Booking.general, () =>
            {
                RuleFor(x => x.BookingCreatorId).NotEmpty().WithMessage("invalid firstname");
                RuleFor(x => x.Id).NotEmpty().WithMessage("invalid lastname");
            });
            
        }

    }

}
