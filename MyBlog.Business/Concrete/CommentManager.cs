using MyBlog.Business.Interfaces;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Concrete
{
    public class CommentManager : GenericManager<Comment> , ICommentService 
    {
        private readonly IGenericDal<Comment> _genericDal;

        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
        
    }
}
