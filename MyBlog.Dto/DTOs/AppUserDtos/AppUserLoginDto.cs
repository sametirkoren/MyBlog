using MyBlog.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Dto.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
