using Microsoft.AspNetCore.Components.Forms;
using FluentValidation;

namespace Calculator.Models.Validators
{
    public class IndividualValidator : AbstractValidator<Individual>
    {
        public IndividualValidator(Microsoft.Extensions.Localization.IStringLocalizer localizeForCodeBehind,
        Microsoft.Extensions.Localization.IStringLocalizer globalLocalizeForCodeBehind)
        {
            RuleFor(o => o.FirstName)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["FirstName"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["FirstName"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(2)
            .WithMessage(x => localizeForCodeBehind["FirstName"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.LastName)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["LastName"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["LastName"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(1)
            .WithMessage(x => localizeForCodeBehind["LastName"] + " " + globalLocalizeForCodeBehind["errMinLen"]);
        } 
    }
}
