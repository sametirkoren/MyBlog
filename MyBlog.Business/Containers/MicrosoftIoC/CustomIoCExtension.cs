using Microsoft.Extensions.DependencyInjection;
using MyBlog.Business.Concrete;
using MyBlog.Business.Interfaces;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MyBlog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}
