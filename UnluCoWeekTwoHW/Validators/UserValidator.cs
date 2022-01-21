using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;

namespace UnluCoWeekTwoHW.Validators
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("ASD");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("WQE");
        }
    }
}
