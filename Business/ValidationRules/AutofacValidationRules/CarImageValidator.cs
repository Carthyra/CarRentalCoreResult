using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.AutofacValidationRules
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotEmpty();
        }
    }
}
