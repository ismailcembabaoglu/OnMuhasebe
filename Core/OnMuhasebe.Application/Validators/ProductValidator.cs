using FluentValidation;
using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.Validators
{
    public class ProductValidator:AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            
        }
    }
}
