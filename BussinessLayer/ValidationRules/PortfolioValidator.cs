using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez !");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Alanı Geçilemez !");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel2 Alanı Boş Geçilemez !");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Geçilemez !");
            RuleFor(x => x.value).NotEmpty().WithMessage("Değer Alanı Boş Geçilemez !");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje Adı En az 5 karakter olmalıdır!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje Adı En fazla 100 karakter olabilir !");

        }
    }
}
