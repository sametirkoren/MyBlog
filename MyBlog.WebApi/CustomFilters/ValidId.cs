using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Business.Interfaces;
using MyBlog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class , ITable , new()
    {
        private readonly IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(dictionary.Value.ToString());

            var entity = _genericService.FindByIdAsync(id).Result;

            if(entity == null)
            {
                context.Result = new NotFoundObjectResult($"{id} değerine sahip nesne bulunamadı");
            }
        }
    }
}
