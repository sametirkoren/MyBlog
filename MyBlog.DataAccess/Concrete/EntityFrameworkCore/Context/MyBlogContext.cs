using Microsoft.EntityFrameworkCore;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class MyBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=MyBlogDb;Integrated Security = true;");
        }


        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<AppUser> AppUsers{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
    }
}
