using FluentValidation;
using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName Boş Geçmeyiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("En Fazla 30 Karakter Girilmelidir.");
        }
    }
}