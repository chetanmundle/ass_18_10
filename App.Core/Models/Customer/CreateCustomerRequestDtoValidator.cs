using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.Customer
{
    public class CreateCustomerRequestDtoValidator : AbstractValidator<CreateCustomerRequestDto>
    {
        public CreateCustomerRequestDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Gender).NotEmpty().MaximumLength(20);
            RuleFor(x => x.AddressLine1).NotEmpty().MaximumLength(150);
            RuleFor(x => x.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.State).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Now);


        }
    }
}
