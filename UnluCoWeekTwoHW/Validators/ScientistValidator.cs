using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;

namespace UnluCoWeekTwoHW.Validators
{
    public class ScientistValidator:AbstractValidator<Scientist>
    {
        public ScientistValidator()
        {
            RuleFor(x => x.ScientistEmail).NotNull().NotEmpty().WithMessage("Email boş Olamaz.");
            RuleFor(x => x.ScientistEmail).EmailAddress().WithMessage("Email formatı yanlış");
            RuleFor(x => x.ScientistName).NotNull().NotEmpty().WithMessage("İsim Boş Olamaz.");
            RuleFor(x => x.ScientistName).MaximumLength(128).WithMessage("İsim fazla uzun kısaltıp giriniz.");
        }
    }
}
