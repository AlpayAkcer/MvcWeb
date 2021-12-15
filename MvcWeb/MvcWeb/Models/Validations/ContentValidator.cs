using FluentValidation;
using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models.Validations
{
    public class ContentValidator : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlığını Boş Geçmeyiniz");
        }
    }
}