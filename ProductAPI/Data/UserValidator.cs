using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ProductAPI.Data
{
    public class UserValidator : AbstractValidator<Product>
    {
        public UserValidator()
        {
            RuleFor(product => product.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz!");
            RuleFor(product => product.ProductColour).NotEmpty().WithMessage("Ürün rengi boş olamaz!");
            RuleFor(product => product.ProductPrice).NotEmpty().WithMessage("Ürün fiyatı boş olamaz!");
        }
    }
}
