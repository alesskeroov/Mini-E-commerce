using Ecommerce_Backend.Application.ViewModels.Products;
using Ecommerce_Backend.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Enter the product name.").MaximumLength(150).MinimumLength(3).WithMessage("Enter the product name between 3 and 150.");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Enter the stock.").Must(s=>s>=0).WithMessage("Stock cannot be negative.");


            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Enter the price.").Must(s=>s>=0).WithMessage("Price cannot be negative.");


        }
    }
}
