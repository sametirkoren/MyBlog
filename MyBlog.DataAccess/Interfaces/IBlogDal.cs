using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Interfaces
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);

        Task<List<Blog>> GetLastFiveAsync();


    }
}
