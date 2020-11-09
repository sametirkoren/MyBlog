using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Business.Concrete;
using MyBlog.Business.Interfaces;
using MyBlog.Business.Tools.JWTool;
using MyBlog.Business.Tools.LogTool;
using MyBlog.Business.ValidationRules.FluentValidation;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Dto.DTOs.AppUserDtos;
using MyBlog.Dto.DTOs.CategoryBlogDtos;
using MyBlog.Dto.DTOs.CategoryDtos;
using MyBlog.Dto.DTOs.CommentDtos;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MyBlog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();


            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, CommentRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<ICustomLogger, NLogAdapter>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CommentAddDto>, CommentAddValidator>();
        }
    }
}
