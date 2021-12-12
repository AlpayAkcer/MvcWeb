using FluentValidation;
using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Validations
{
    public class CategoryValidator : AbstractValidator<Categories>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Başlığını Boş Geçmeyiniz");
        }
    }
}