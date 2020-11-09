using FluentValidation;
using MyBlog.Dto.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("Email alanı boş bırakılamaz.");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.");
          
        }
    }
}
