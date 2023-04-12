using Business.Constants.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class FvReceiptValidator : AbstractValidator<Receipt>
    {
        public FvReceiptValidator()
        {
            RuleFor(r => r.CategoryId).NotEmpty();
            RuleFor(r => r.CategoryId).GreaterThanOrEqualTo(1);

            RuleFor(r => r.CompanyId).NotEmpty();
            RuleFor(r => r.CompanyId).GreaterThanOrEqualTo(1);

            RuleFor(r => r.PaymentTypeId).NotEmpty();
            RuleFor(r => r.PaymentTypeId).GreaterThanOrEqualTo(1);

            RuleFor(r => r.Amount).NotEmpty();
            RuleFor(r => r.Amount).GreaterThanOrEqualTo(1);

            RuleFor(r => r.Date).NotEmpty();
            RuleFor(r => r.Date).Must(IsValidDate).WithMessage(ValidationMessages.InvalidDate);
        }

        private bool IsValidDate(DateTime date)
        {
            if (date.DayOfYear > DateTime.Now.DayOfYear)
                return false;

            return true;
        }
    }
}
