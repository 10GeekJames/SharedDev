using Microsoft.AspNetCore.Components.Forms;
using FluentValidation;

namespace Calculator.Models.Validators
{
    public class Calculator2CharacterValidator : AbstractValidator<Calculator2Character>
    {
        public Calculator2CharacterValidator(Microsoft.Extensions.Localization.IStringLocalizer localizeForCodeBehind,
        Microsoft.Extensions.Localization.IStringLocalizer globalLocalizeForCodeBehind)
        {
            RuleFor(o => o.Name)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["Name"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["Name"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(20)
            .WithMessage(x => localizeForCodeBehind["Name"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.Bio)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["Bio"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["Bio"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(20)
            .WithMessage(x => localizeForCodeBehind["Bio"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.WhatISeek)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["WhatISeek"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["WhatISeek"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(20)
            .WithMessage(x => localizeForCodeBehind["WhatISeek"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.WhyMe)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["WhyMe"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["WhyMe"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(20)
            .WithMessage(x => localizeForCodeBehind["WhyMe"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.WhyYou)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["WhyYou"] + " " + globalLocalizeForCodeBehind["errIsRequired"])
            .MaximumLength(240)
            .WithMessage(x => localizeForCodeBehind["WhyYou"] + " " + globalLocalizeForCodeBehind["errMaxLen"])
            .MinimumLength(20)
            .WithMessage(x => localizeForCodeBehind["WhyYou"] + " " + globalLocalizeForCodeBehind["errMinLen"]);

            RuleFor(o => o.SkillRating)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["SkillRating"] + " " +
            globalLocalizeForCodeBehind["errIsRequired"])
            .InclusiveBetween(1, 7)
            .WithMessage(x => localizeForCodeBehind["ExperienceRating"] + " " +
            globalLocalizeForCodeBehind["errInclusiveBetween"]);

            RuleFor(o => o.IntensityRating)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["IntensityRating"] + " " +
            globalLocalizeForCodeBehind["errIsRequired"])
            .InclusiveBetween(1, 7)
            .WithMessage(x => localizeForCodeBehind["ExperienceRating"] + " " +
            globalLocalizeForCodeBehind["errInclusiveBetween"]);

            RuleFor(o => o.ExperienceRating)
            .NotEmpty()
            .WithMessage(x => localizeForCodeBehind["ExperienceRating"] + " " +
            globalLocalizeForCodeBehind["errIsRequired"])
            .InclusiveBetween(1, 7)
            .WithMessage(x => localizeForCodeBehind["ExperienceRating"] + " " +
            globalLocalizeForCodeBehind["errInclusiveBetween"]);
        } 
    }
}
