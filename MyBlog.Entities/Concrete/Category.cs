using MyBlog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
