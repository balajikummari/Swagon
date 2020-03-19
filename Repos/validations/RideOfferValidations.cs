using FluentValidation;
using Swagon.DataBase.DataModel;

namespace Swagon.DataBase
{
    public class RideOfferValidations : AbstractValidator<RideOffer>
    {
        public RideOfferValidations()
        {
            RuleSet(RuleSets.RideOffer.General, () =>
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("invalid fromcityID");
                RuleFor(x => x.FromCityId).NotEmpty().WithMessage("invalid fromcityID");
                RuleFor(x => x.ToCityId).NotEmpty().WithMessage("invalid toCityId");
                RuleFor(x => x.OfferCreatorId).NotEmpty().WithMessage("invalid OfferCreatorId");
                RuleFor(x => x.CountryCode).NotEmpty().WithMessage("invalid CountryCode");
                RuleFor(x => x.EntireJourneyFare).NotEmpty().WithMessage("invalid EntireJourneyFare");
                RuleFor(x => x.JourneyDate).NotEmpty().WithMessage("invalid JourneyDate");
            });
        }
    }
}
