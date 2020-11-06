using MyBlog.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Dto.DTOs.AppUserDtos
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
    }
}
