using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Interfaces
{
    public interface ICategoryService  : IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByIdAsync();
    }
}
