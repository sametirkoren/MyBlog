using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CommentRepository : EfGenericRepository<Comment> , ICommentDal
    {
    }
}
