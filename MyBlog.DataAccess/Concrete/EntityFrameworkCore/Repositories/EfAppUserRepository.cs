using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser> , IAppUserDal
    {

        private readonly MyBlogContext _context;
        public EfAppUserRepository(MyBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
