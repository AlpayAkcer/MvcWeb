using FluentValidation;
using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Validations
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Role Adını Boş Geçmeyiniz");
            RuleFor(x => x.RoleName).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
        }
    }
}