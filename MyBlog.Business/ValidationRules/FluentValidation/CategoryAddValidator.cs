using FluentValidation;
using MyBlog.Dto.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {

        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
