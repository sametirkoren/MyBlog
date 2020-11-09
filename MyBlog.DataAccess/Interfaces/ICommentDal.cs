﻿using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Interfaces
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId , int? parentId);

    }
}
