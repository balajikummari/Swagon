using FluentValidation;
using Swagon.DataBase.DataModel;

namespace Swagon.DataBase
{
    public class CityValidations : AbstractValidator<City>
    {
        public CityValidations()
        {
            RuleSet(RuleSets.City.coordiantes, () =>
            {

            });
        }
    }

}
