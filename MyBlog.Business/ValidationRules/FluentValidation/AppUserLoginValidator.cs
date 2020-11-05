using FluentValidation;
using MyBlog.Dto.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı  boş geçilemez");
        }
    }
}
