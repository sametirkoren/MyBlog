using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Models
{
    public class BlogAddModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }
    }
}
