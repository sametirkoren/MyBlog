using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CommentRepository : EfGenericRepository<Comment> , ICommentDal
    {
        private readonly MyBlogContext _context;
        public CommentRepository(MyBlogContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            List<Comment> result = new List<Comment>();
            await GetComments(blogId, parentId, result);
            return result;
        }

        private async Task GetComments(int blogId , int? parentId, List<Comment> result)
        {
          
            var comments = await _context.Comments.Where(I => I.BlogId == blogId && I.ParentCommentId == parentId).OrderByDescending(I => I.PostedTime).ToListAsync();
            if(comments.Count > 0)
            {
                foreach(var comment in comments)
                {
                    if(comment.SubComments == null)
                    {
                        comment.SubComments = new List<Comment>();
                    }
                    await GetComments(comment.BlogId, comment.Id, comment.SubComments);

                    if (!result.Contains(comment))
                    {
                        result.Add(comment);
                    }
                }
            }
        }

    }
}
